namespace D20Tek.Bookshelf.Web.Features.Books;

internal interface IBooksService
{
    public Task<Result<IEnumerable<BookEntity>>> GetAll();

    public Task<Result<BookEntity>> GetById(string id);

    public Task<Result<IEnumerable<BookEntity>>> GetByQuery(BookQuery query);

    public Task<string[]> GetAuthors();

    public Task<string[]> GetMediaTypes();
}
