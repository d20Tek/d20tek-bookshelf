namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListFilters
{
    private Filters _filters = Filters.Empty;
    private bool _isExpanded = false;
    private IEnumerable<string> _authors = [];
    private IEnumerable<string> _mediatypes = [];

    [Parameter]
    public EventCallback<BookQuery> SearchClicked { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _authors = await _bookService.GetAuthors();
        _mediatypes = await _bookService.GetMediaTypes();
        _filters = await _storage.GetItemAsync<Filters>(Constants.Books.BookFiltersKey) ?? Filters.Empty;
    }

    protected override Task OnAfterRenderAsync(bool firstRender) =>
        (firstRender) ? GetExpansionState() : Task.CompletedTask;

    private async Task GetExpansionState()
    {
        var width = await _jSRuntime.InvokeAsync<int>(Constants.WindowWidthFuncName, null);
        _isExpanded = width >= Constants.BootstrapMdBreakpoint;
        StateHasChanged();
    }

    private void ToggleExpanded() => _isExpanded = !_isExpanded;

    private async Task Search()
    {
        await _storage.SetItemAsync(Constants.Books.BookFiltersKey, _filters);
        await SearchClicked.InvokeAsync(new(_filters.Author, _filters.EditionCode, _filters.MediaType));
    }

    private async Task ResetFilters()
    {
        _filters = Filters.Empty;
        await _storage.RemoveItemAsync(Constants.Books.BookFiltersKey);
    }
}
