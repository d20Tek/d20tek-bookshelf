namespace D20Tek.Bookshelf.Web.Domain;

public class BookLink
{
    public enum Type
    {
        Amazon,
        Ebay,
        DriveThruRPG,
        Wikipedia,
    }

    public Type Source { get; }

    public string Url { get; }

    public BookLink(Type source, string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(url, nameof(url));
        Source = source;
        Url = url;
    }

    public string GetFullUrl() =>
        Source switch
        {
            BookLink.Type.Ebay => Url + Constants.Books.AffiliateSuffixEbay,
            BookLink.Type.DriveThruRPG => Url + Constants.Books.AffiliateSuffixDriveThruRpg,
            _ => Url
        };
}
