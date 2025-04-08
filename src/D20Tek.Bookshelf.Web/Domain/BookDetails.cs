namespace D20Tek.Bookshelf.Web.Domain;

internal sealed class BookDetails
{
    public string EditionCode { get; }

    public DndEdition Edition { get; }

    public string Publisher { get; }

    public string PublishedOn { get; }

    public string ImageLink { get; }

    public int Pages { get; }

    public string MediaType { get; }

    public BookDetails(
        string editionCode,
        string publisher,
        string publishedOn,
        string imageLink,
        int pages,
        string mediaType)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(editionCode, nameof(editionCode));
        ArgumentNullException.ThrowIfNullOrEmpty(imageLink, nameof(imageLink));
        ArgumentNullException.ThrowIfNullOrEmpty(publisher, nameof(publisher));
        ArgumentNullException.ThrowIfNullOrEmpty(publishedOn, nameof(publishedOn));
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(pages, 0, nameof(pages));
        ArgumentNullException.ThrowIfNull(mediaType, nameof(mediaType));

        EditionCode = editionCode;
        Edition = Editions.GetEdition(editionCode);
        Publisher = publisher;
        PublishedOn = publishedOn;
        ImageLink = imageLink;
        Pages = pages;
        MediaType = mediaType;
    }
}
