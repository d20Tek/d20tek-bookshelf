namespace D20Tek.Bookshelf.Web.Domain;

public sealed class Author
{
    public string Name { get; }

    public Url Link { get; }

    public Author(string name, Url link)
    {
        Name = name;
        Link = link;
    }
}
