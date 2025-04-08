namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListComponent
{
    private BookEntity[]? _books;

    protected override async Task OnInitializedAsync()
    {
        _books = await _service.GetAll();
    }
}
