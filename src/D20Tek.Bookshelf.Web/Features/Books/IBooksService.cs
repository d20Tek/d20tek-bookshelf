namespace D20Tek.Bookshelf.Web.Features.Books;

internal interface IBooksService
{
    public Task<Result<IEnumerable<BookEntity>>> GetAll();

    public Task<Result<BookEntity>> GetById(string id);

    public Task<Result<PagedList<BookEntity>>> GetByQuery(BookQuery query);

    public Task<IEnumerable<string>> GetAuthors();

    public Task<IEnumerable<string>> GetMediaTypes();
}
