using D20Tek.Bookshelf.Web.Domain;
using System.Net.Http.Json;

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

    public async Task<BookEntity[]> GetAll() => await GetCachedList();

    public async Task<Result<BookEntity>> GetById(string id)
    {
        var books = await GetCachedList();
        return books.Where(x => x.Id == id)
                    .Select(entity => (Result<BookEntity>)entity)
                    .DefaultIfEmpty(NotFoundError<BookEntity>(id))
                    .First();
    }

    public async Task<BookEntity[]> GetCachedList() =>
        _cachedBooks = _cachedBooks.Length <= 0 ?
                            await _httpClient.GetFromJsonAsync<BookEntity[]>(_baseUrl) ?? [] :
                            _cachedBooks;
}
