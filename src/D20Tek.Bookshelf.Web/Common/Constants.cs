namespace D20Tek.Bookshelf.Web.Common;

internal static partial class Constants
{
    public const string DefaultErrorTitle = "Application error";

    public const string DefaultErrorCode = "ServiceApi";

    public static int ServiceSleepDelay { get; internal set; } = 0;

    public const int BootstrapMdBreakpoint = 768;
    public const string WindowWidthFuncName = "blazorGetWindowWidth";

    public const string DonationUrl = "https://ko-fi.com/V7V8UGPMB";

    public const string UnexpectedServiceMessage = "Unexpected server error from backend service.";

    public static Error UnexpectedServiceError(string code) => Error.Unexpected(code, UnexpectedServiceMessage);

    public static Error ServiceRequestError(string code) =>
        Error.Failure(code, "Unable to connect with HabitTracker service. Please try again later.");

    public static string UnexpectedRequestMessage(string requestName) =>
        $"Unexpected error... {requestName} request could not be created.";

    internal static class Loading
    {
        public const string DefaultIconClass = "bi bi-play";

        public const string SpinnerClass = "spinner-border spinner-border-sm";

        public const string DefaultLabel = "Loading...";

        public static string GetLabelClass(string label) => string.IsNullOrEmpty(label) ? "visually-hidden" : "ms-1";
    }
}
