namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListFilters
{
    public class Filters
    {
        public string Author { get; set; }

        public string EditionCode { get; set; }

        public string MediaType { get; set; }

        public Filters(string author, string editionCode, string mediaType)
        {
            Author = author;
            EditionCode = editionCode;
            MediaType = mediaType;
        }

        public static Filters Empty => new(string.Empty, string.Empty, string.Empty);
    }

    private Filters? _filters;
    private bool isExpanded = false;
    private IEnumerable<string> _authors = [];
    private IEnumerable<string> _mediatypes = [];

    [Parameter]
    public EventCallback<BookQuery> SearchClicked { get; set; }

    protected override void OnInitialized()
    {
        _authors = _bookService.GetAuthors();
        _mediatypes = _bookService.GetMediaTypes();

        // todo: fix authors and media types lists empty because books file wasn't loaded yet.
        // need to make sure books loaded during these get methods.
    }

    protected override async Task OnInitializedAsync()
    {
        _filters = await _storage.GetItemAsync<Filters>(Constants.Books.BookFiltersKey) ?? Filters.Empty;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var width = await _jSRuntime.InvokeAsync<int>(Constants.WindowWidthFuncName, null);
            isExpanded = width >= Constants.BootstrapMdBreakpoint;
            StateHasChanged();
        }
    }

    private void ToggleExpanded() => isExpanded = !isExpanded;

    private async Task Search()
    {
        await _storage.SetItemAsync(Constants.Books.BookFiltersKey, _filters);
        await SearchClicked.InvokeAsync(new(_filters!.Author, _filters.EditionCode, _filters.MediaType));
    }

    private async Task ResetFilters()
    {
        _filters = Filters.Empty;
        await _storage.RemoveItemAsync(Constants.Books.BookFiltersKey);
    }
}
