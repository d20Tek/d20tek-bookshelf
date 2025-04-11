namespace D20Tek.Bookshelf.Web.Common;

internal static partial class Constants
{
    internal static class Books
    {
        public const string ServiceUrl = "data/books.json";

        public static string DetailsUrl(string id) => $"/books/{id}";

        public static Failure<T> NotFoundError<T>(string id) where T : notnull =>
            Error.NotFound("BookEntity.NotFound", $"Book with id={id} not found.");

        public const string AffiliateSuffixEbay =
            "&mkcid=1&mkrid=711-53200-19255-0&siteid=0&campid=5339107475&customid=d20TekBooks&toolid=10001&mkevt=1";

        public const string AffiliateSuffixDriveThruRpg = "?affiliate_id=1234567";
    }
}
