namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class DetailBook
{
    private Error[] _errors = [];
    private Option<BookEntity> _book = Option<BookEntity>.None();

    [Parameter]
    public string Id { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync() =>
        await _bookService.GetById(Id)
                          .HandleResultAsync(b => _book = b, e => _errors = e);
}
