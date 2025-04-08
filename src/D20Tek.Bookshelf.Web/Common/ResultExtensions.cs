namespace D20Tek.Bookshelf.Web.Common;

internal static class ResultExtensions
{
    internal static async Task HandleResultAsync<T>(
        this Task<Result<T>> result, Action<T> onSuccess, Action<string> onFailure)
        where T : notnull
    {
        var r = await result;
        if (r.IsSuccess)
            onSuccess(r.GetValue());
        else
            onFailure(r.GetErrors().First().ToString());
    }

    internal static async Task HandleResultAsync<T>(
        this Task<Result<T>> result, Action<T> onSuccess, Action<Error[]> onFailure)
        where T : notnull
    {
        var r = await result;
        if (r.IsSuccess)
            onSuccess(r.GetValue());
        else
            onFailure(r.GetErrors());
    }

    internal static async Task<T> HandleErrorAsync<T>(
        this Task<Result<T>> result, Action<Error[]> onFailure, T defaultValue)
        where T : notnull
    {
        var r = await result;
        if (r.IsSuccess)
        {
            return r.GetValue();
        }
        else
        {
            onFailure(r.GetErrors());
            return defaultValue;
        }
    }
}
