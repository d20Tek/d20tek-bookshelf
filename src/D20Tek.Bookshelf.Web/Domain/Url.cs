namespace D20Tek.Bookshelf.Web.Domain;

public sealed class Url
{
    public string Value { get; }

    public Url(string link)
    {
        Value = link;
    }
}
