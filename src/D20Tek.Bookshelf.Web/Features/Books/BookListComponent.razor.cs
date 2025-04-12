namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListComponent
{
    public class FilterViewModel
    {
        public string Author { get; set; } = string.Empty;

        public string EditionCode { get; set; } = string.Empty;

        public string MediaType { get; set; } = string.Empty;
    }

    private FilterViewModel _vmFilter = new();
    private IEnumerable<BookEntity>? _books;
    private Error[] _errors = [];

    protected override async Task OnInitializedAsync()
    {
        _books = await _service.GetAll().HandleErrorAsync(e => _errors = e, []);
    }

    private void NavigateToDetails(string id) => _nav.NavigateTo(Constants.Books.DetailsUrl(id));

    private void SearchBooks() { }
}
