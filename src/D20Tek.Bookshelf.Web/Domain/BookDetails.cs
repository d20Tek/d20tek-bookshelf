namespace D20Tek.Bookshelf.Web.Domain;

public class BookDetails
{
    public Editions Edition { get; }

    public DateOnly PublishedOn { get; }

    public Url ImageLink { get; }

    public int Pages { get; }

    public string TsrNum { get; }

    public string Isbn { get; }

    public BookDetails(Editions edition, DateOnly publishedOn, Url imageLink, int pages, string tsrNum, string isbn)
    {
        Edition = edition;
        PublishedOn = publishedOn;
        ImageLink = imageLink;
        Pages = pages;
        TsrNum = tsrNum;
        Isbn = isbn;
    }
}
