namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListComponent
{
    private List<BookEntity>? _books;
    private Error[] _errors = [];
    private int _totalCount = 0;

    protected override async Task OnInitializedAsync() => await SearchBooks(BookQuery.Empty);

    private void NavigateToDetails(string id) => _nav.NavigateTo(Constants.Books.DetailsUrl(id));

    private async Task SearchBooks(BookQuery query)
    {
        var results = await _service.GetByQuery(query)
                                    .HandleErrorAsync(e => _errors = e, new(0, []));
        _books = [.. results.Items];
        _totalCount = results.TotalCount;
    }

    private async Task FetchMoreBooks(BookQuery query)
    {
        query.UpdateSkip(GetLocalBookCount());
        var nextPage = await _service.GetByQuery(query)
                                     .HandleErrorAsync(e => _errors = e, new(0, []));
        _books?.AddRange();
    }

    private bool HasMorePages() => GetLocalBookCount() < _totalCount;

    private int GetLocalBookCount() => _books?.Count ?? 0;
}
