namespace D20Tek.Bookshelf.Web.Domain;

public class BookDetails
{
    public string EditionCode { get; }

    public DateOnly PublishedOn { get; }

    public string ImageLink { get; }

    public int Pages { get; }

    public string TsrNum { get; }

    public BookDetails(string editionCode, DateOnly publishedOn, string imageLink, int pages, string tsrNum)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(editionCode, nameof(editionCode));
        ArgumentNullException.ThrowIfNullOrEmpty(imageLink, nameof(imageLink));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pages, 0, nameof(pages));
        ArgumentNullException.ThrowIfNullOrEmpty(tsrNum, nameof(tsrNum));

        EditionCode = editionCode;
        PublishedOn = publishedOn;
        ImageLink = imageLink;
        Pages = pages;
        TsrNum = tsrNum;
    }
}
