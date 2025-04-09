namespace D20Tek.Bookshelf.Web.Features.Books;

internal sealed class BooksService : IBooksService
{
    private const string _baseUrl = "data/books.json";

    public static Failure<T> NotFoundError<T>(string id) where T : notnull =>
        Error.NotFound("BookEntity.NotFound", $"Book with id={id} not found.");

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
                                .DefaultIfEmpty(NotFoundError<BookEntity>(id))
                                .First());
    }

    public async Task<Result<BookEntity[]>> GetCachedList() =>
        (_cachedBooks.Length <= 0) ?
            await _httpClient.TryGetFromJsonAsync<BookEntity[]>(_baseUrl, [], _logger) :
            _cachedBooks;
}
