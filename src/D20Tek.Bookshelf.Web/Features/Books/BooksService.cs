namespace D20Tek.Bookshelf.Web.Features.Books;

internal sealed class BooksService : IBooksService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<BooksService> _logger;
    private IEnumerable<BookEntity> _cachedBooks = [];

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

    // todo: change these to get calculated and cached when the books are loaded.
    public async Task<string[]> GetAuthors()
    {
        var books = await GetCachedList();
        return books.Match(
            b => b.SelectMany(b => b.Authors)
                  .Select(a => a.Name)
                  .Distinct()
                  .OrderBy(a => a)
                  .ToArray(),
            e => []);
    }

    public async Task<string[]> GetMediaTypes()
    {
        var books = await GetCachedList();
        return books.Match(
            b => b.Select(b => b.Details.MediaType)
                  .Distinct()
                  .OrderBy(m => m)
                  .ToArray(),
            e => []);
    }

    private async Task<Result<IEnumerable<BookEntity>>> GetCachedList()
    {
        if (_cachedBooks.Count() <= 0)
        {
            var result = await _httpClient.TryGetFromJsonAsync<IEnumerable<BookEntity>>(Constants.Books.ServiceUrl, _logger);
            if (result.IsSuccess) _cachedBooks = result.GetValue();

            return result;
        }
        else
        {
            return Result<IEnumerable<BookEntity>>.Success(_cachedBooks);
        }
    }
}
