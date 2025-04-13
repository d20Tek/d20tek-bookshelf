namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListComponent
{
    private IEnumerable<BookEntity>? _books;
    private Error[] _errors = [];

    protected override async Task OnInitializedAsync() => await SearchBooks(BookQuery.Empty);

    private void NavigateToDetails(string id) => _nav.NavigateTo(Constants.Books.DetailsUrl(id));

    private async Task SearchBooks(BookQuery query)
    {
        _books = await _service.GetByQuery(query)
                               .HandleErrorAsync(e => _errors = e, []);
    }
}
