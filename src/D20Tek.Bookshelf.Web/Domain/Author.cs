namespace D20Tek.Bookshelf.Web.Domain;

public sealed class Author
{
    public required string Name { get; init; }

    public required string Url { get; init; }

    public Author(string name, string link)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrEmpty(link, nameof(link));

        Name = name;
        Url = link;
    }
}
