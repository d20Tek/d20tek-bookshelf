namespace D20Tek.Bookshelf.Web.Features.Books;

internal sealed class BooksService : IBooksService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BooksService> _logger;
    private BookEntity[] _cachedBooks = [];

    public BooksService(HttpClient httpClient, ILogger<BooksService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Result<BookEntity[]>> GetAll() => await GetCachedList();

    public async Task<Result<BookEntity>> GetById(string id)
    {
        var books = await GetCachedList();
        return books.Bind(b => b.Where(x => x.Id == id)
                                .Select(entity => (Result<BookEntity>)entity)
                                .DefaultIfEmpty(Constants.Books.NotFoundError<BookEntity>(id))
                                .First());
    }

    public async Task<Result<BookEntity[]>> GetCachedList()
    {
        if (_cachedBooks.Length <= 0)
        {
            var result = await _httpClient.TryGetFromJsonAsync<BookEntity[]>(Constants.Books.ServiceUrl, _logger);
            if (result.IsSuccess) _cachedBooks = result.GetValue();

            return result;
        }
        else
        {
            return _cachedBooks;
        }
    }
}
