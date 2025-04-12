namespace D20Tek.Bookshelf.Web.Features.Books;

internal static class BookListExtensions
{
    public static IEnumerable<BookEntity> ApplyFilters(this IEnumerable<BookEntity> books, BookQuery query)
    {
        if (query.EditionCode.IsSome && query.EditionCode.Get() is string edition)
        {
            books = books.Where(b => b.Details.EditionCode == edition);
        }
        if (query.MediaType.IsSome && query.MediaType.Get() is string mediaType)
        {
            books = books.Where(b => b.Details.MediaType == mediaType);
        }
        if (query.Author.IsSome && query.Author.Get() is string author)
        {
            books = books.Where(b => b.Authors.Any(a => a.Name == author));
        }

        if (query.Take > 0)
        {
            books = books.Take(query.Take);
        }
        if (query.Skip > 0)
        {
            books = books.Skip(query.Skip);
        }

        return books;
    }
}
