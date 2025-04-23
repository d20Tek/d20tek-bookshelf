namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListFilters
{
    public class Filters
    {
        public string Author { get; set; }

        public string EditionCode { get; set; }

        public string MediaType { get; set; }

        public Filters(string author, string editionCode, string mediaType)
        {
            Author = author;
            EditionCode = editionCode;
            MediaType = mediaType;
        }

        public static Filters Empty => new(string.Empty, string.Empty, string.Empty);
    }
}
