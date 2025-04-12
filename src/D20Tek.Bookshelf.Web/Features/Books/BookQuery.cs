namespace D20Tek.Bookshelf.Web.Features.Books;

internal class BookQuery
{
    public Option<string> Author { get; } = Option<string>.None();

    public Option<string> EditionCode { get; } = Option<string>.None();

    public Option<string> MediaType { get; } = Option<string>.None();

    public int Take { get; }

    public int Skip { get; }

    public BookQuery(string? author, string? editionCode, string? mediaType, int take, int skip)
    {
        Author = author.ToOption();
        EditionCode = editionCode.ToOption();
        MediaType = mediaType.ToOption();
        Take = take;
        Skip = skip;

    }
}
