namespace D20Tek.Bookshelf.Web.Domain;

internal sealed class Author
{
    public string Name { get; init; }

    public string Url { get; init; }

    public Author(string name, string url)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrEmpty(url, nameof(url));

        Name = name;
        Url = url;
    }
}
