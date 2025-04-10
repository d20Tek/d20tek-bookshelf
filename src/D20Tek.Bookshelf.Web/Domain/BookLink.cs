namespace D20Tek.Bookshelf.Web.Domain;

public class BookLink
{
    public enum Type
    {
        Amazon,
        Ebay,
        Wikipedia
    }

    public Type Source { get; }

    public string Url { get; }

    public BookLink(Type source, string url)
    {
        ArgumentException.ThrowIfNullOrEmpty(url, nameof(url));
        Source = source;
        Url = url;
    }
}
