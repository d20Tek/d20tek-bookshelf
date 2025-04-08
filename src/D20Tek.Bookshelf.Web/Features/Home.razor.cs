using D20Tek.Bookshelf.Web.Domain;

namespace D20Tek.Bookshelf.Web.Features;

public partial class Home
{
    private BookEntity[]? _books;

    protected override async Task OnInitializedAsync()
    {
        _books = await _service.GetAll();
    }
}
