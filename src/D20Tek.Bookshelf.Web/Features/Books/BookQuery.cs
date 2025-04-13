namespace D20Tek.Bookshelf.Web.Features.Books;

public class BookQuery
{
    public Option<string> Author { get; }

    public Option<string> EditionCode { get; }

    public Option<string> MediaType { get; }

    public int Take { get; }

    public int Skip { get; }

    public BookQuery(
        string author,
        string editionCode,
        string mediaType,
        int skip = 0,
        int take = Constants.Books.DefaultPageSize)
    {
        Author = ConvertString(author);
        EditionCode = ConvertString(editionCode);
        MediaType = ConvertString(mediaType);
        Take = take;
        Skip = skip;
    }
    public static BookQuery Empty => new(string.Empty, string.Empty, string.Empty);

    private static Option<string> ConvertString(string value) =>
        string.IsNullOrEmpty(value) ? Option<string>.None() : value;
}
