namespace D20Tek.Bookshelf.Web.Domain;

internal sealed class BookEntity
{
    public string Id { get; }

    public string Title { get; }

    public Author[] Authors { get; }

    public string[] Description { get; }

    public BookDetails Details { get; }

    public BookIdentifiers AltIds { get; }

    public BookLink[] Links { get; }

    public BookEntity(
        string id,
        string title,
        Author[] authors,
        string[] description,
        BookDetails details,
        BookIdentifiers altIds,
        BookLink[] links)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(id, nameof(id));
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));

        Id = id;
        Title = title;
        Authors = authors;
        Description = description;
        Details = details;
        AltIds = altIds;
        Links = links;
    }
}
