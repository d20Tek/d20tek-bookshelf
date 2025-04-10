namespace D20Tek.Bookshelf.Web.Domain;

public sealed class BookIdentifiers
{
    public string Ibsn { get; }

    public string TsrNum { get; }

    public string AltId { get; }

    public BookIdentifiers(string ibsn, string tsrNum, string altId)
    {
        Ibsn = ibsn;
        TsrNum = tsrNum;
        AltId = altId;
    }

    public static BookIdentifiers Empty = new(string.Empty, string.Empty, string.Empty);
}
