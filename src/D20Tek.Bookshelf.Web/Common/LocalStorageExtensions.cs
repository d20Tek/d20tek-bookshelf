using Blazored.LocalStorage;

namespace D20Tek.Bookshelf.Web.Common;

internal static class LocalStorageExtensions
{
    private const string _expirationKey = "-expires";

    public static async Task<T> GetOrCreateAsync<T>(
        this ILocalStorageService localStorage,
        string key,
        Func<Task<T>> factory,
        TimeSpan? cacheDuration = null)
    {

        var cached = await localStorage.GetItemAsync<T>(key);
        var hasExpired = await localStorage.HasCacheExpired(key);
        return (cached is not null && hasExpired is false) ?
            cached :
            await CreateAsync(localStorage, key, factory, cacheDuration);
    }

    private static async Task<T> CreateAsync<T>(
        this ILocalStorageService localStorage,
        string key,
        Func<Task<T>> factory,
        TimeSpan? cacheDuration)
    {
        var result = await factory();
        await localStorage.SetItemAsync(key, result);
        await localStorage.SetCacheExpiration(key, cacheDuration);

        return result;
    }

    private static async Task SetCacheExpiration(
        this ILocalStorageService localStorage,
        string key,
        TimeSpan? cacheDuration)
    {
        if (cacheDuration is not null)
        {
            await localStorage.SetItemAsync(key + _expirationKey, DateTimeOffset.Now.Add(cacheDuration.Value));
        }
    }

    private static async Task<bool> HasCacheExpired(this ILocalStorageService localStorage, string key)
    {
        var expiration = await localStorage.GetItemAsync<DateTimeOffset?>(key + _expirationKey);
        return expiration is not null && DateTimeOffset.Now > expiration;
    }
}
