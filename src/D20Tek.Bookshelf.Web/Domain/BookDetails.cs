    namespace D20Tek.Bookshelf.Web.Domain;

public class BookDetails
{
    public string EditionCode { get; }

    public DndEdition Edition { get; }

    public string PublishedOn { get; }

    public string ImageLink { get; }

    public int Pages { get; }

    public string TsrNum { get; }

    public BookDetails(string editionCode, string publishedOn, string imageLink, int pages, string tsrNum)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(editionCode, nameof(editionCode));
        ArgumentNullException.ThrowIfNullOrEmpty(imageLink, nameof(imageLink));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pages, 0, nameof(pages));

        EditionCode = editionCode;
        Edition = Editions.GetEdition(editionCode);
        PublishedOn = publishedOn;
        ImageLink = imageLink;
        Pages = pages;
        TsrNum = tsrNum;
    }
}
