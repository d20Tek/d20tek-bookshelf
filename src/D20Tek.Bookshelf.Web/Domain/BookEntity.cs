namespace D20Tek.Bookshelf.Web.Domain;

public sealed class BookEntity
{
    public string Id { get; }

    public string Title { get; }

    public Author[] Authors { get; }

    public string[] Description { get; }

    public BookDetails Details { get; }

    public BookEntity(string id, string title, Author[] authors, string[] description, BookDetails details)
    {
        Id = id;
        Title = title;
        Authors = authors;
        Description = description;
        Details = details;
    }
}
