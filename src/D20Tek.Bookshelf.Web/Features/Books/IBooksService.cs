namespace D20Tek.Bookshelf.Web.Features.Books;

internal interface IBooksService
{
    public Task<Result<BookEntity[]>> GetAll();

    public Task<Result<BookEntity>> GetById(string id);
}
