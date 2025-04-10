namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListComponent
{
    private BookEntity[]? _books;
    private Error[] _errors = [];

    protected override async Task OnInitializedAsync()
    {
        _books = await _service.GetAll().HandleErrorAsync(e => _errors = e, []);
    }

    private void NavigateToDetails(string id) => _nav.NavigateTo(Constants.Books.DetailsUrl(id));
}
