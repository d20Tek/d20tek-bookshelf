namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListComponent
{
    private List<BookEntity>? _books;
    private Error[] _errors = [];
    private int _totalCount = 0;
    private BookQuery _currentQuery = BookQuery.Empty;

    protected override async Task OnInitializedAsync() => await SearchBooks(_currentQuery);

    private void NavigateToDetails(string id) => _nav.NavigateTo(Constants.Books.DetailsUrl(id));

    private async Task SearchBooks(BookQuery query)
    {
        _currentQuery = query;
        var results = await _service.GetByQuery(_currentQuery)
                                    .HandleErrorAsync(e => _errors = e, new(0, []));
        _books = [.. results.Items];
        _totalCount = results.TotalCount;
    }

    private async Task FetchMoreBooks()
    {
        _currentQuery.UpdateSkip(GetLocalBookCount());
        var nextPage = await _service.GetByQuery(_currentQuery)
                                     .HandleErrorAsync(e => _errors = e, new(0, []));
        _books?.AddRange(nextPage.Items);
    }

    private bool HasMorePages() => GetLocalBookCount() < _totalCount;

    private int GetLocalBookCount() => _books?.Count ?? 0;
}
