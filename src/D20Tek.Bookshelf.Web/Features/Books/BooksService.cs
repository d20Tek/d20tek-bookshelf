namespace D20Tek.Bookshelf.Web.Features.Books;

internal sealed class BooksService : IBooksService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BooksService> _logger;
    private IEnumerable<BookEntity> _cachedBooks = [];
    private IEnumerable<string> _cachedAuthors = [];
    private IEnumerable<string> _cachedMediaTypes = [];

    public BooksService(HttpClient httpClient, ILogger<BooksService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Result<IEnumerable<BookEntity>>> GetAll() => await GetCachedList();

    public async Task<Result<BookEntity>> GetById(string id)
    {
        var books = await GetCachedList();
        return books.Bind(b => b.Where(x => x.Id == id)
                                .Select(entity => (Result<BookEntity>)entity)
                                .DefaultIfEmpty(Constants.Books.NotFoundError<BookEntity>(id))
                                .First());
    }

    public async Task<Result<IEnumerable<BookEntity>>> GetByQuery(BookQuery query)
    {
        var books = await GetCachedList();
        return books.Map(b => b.ApplyFilters(query));
    }

    public IEnumerable<string> GetAuthors() => _cachedAuthors;

    public IEnumerable<string> GetMediaTypes() => _cachedMediaTypes;

    private async Task<Result<IEnumerable<BookEntity>>> GetCachedList()
    {
        if (_cachedBooks.Count() <= 0)
        {
            var result = await _httpClient.TryGetFromJsonAsync<IEnumerable<BookEntity>>(Constants.Books.ServiceUrl, _logger);
            if (result.IsSuccess) CacheEntities(result.GetValue());

            return result;
        }
        else
        {
            return Result<IEnumerable<BookEntity>>.Success(_cachedBooks);
        }
    }

    private void CacheEntities(IEnumerable<BookEntity> books)
    {
        _cachedBooks = books;
        _cachedMediaTypes = books.Select(b => b.Details.MediaType)
                              .Distinct()
                              .OrderBy(m => m);
        _cachedAuthors = books.SelectMany(b => b.Authors)
                              .Select(a => a.Name)
                              .Distinct()
                              .OrderBy(a => a);
    }
}
