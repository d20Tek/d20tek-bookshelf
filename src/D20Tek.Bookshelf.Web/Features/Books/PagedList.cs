namespace D20Tek.Bookshelf.Web.Features.Books;

public class PagedList<T>
    where T : notnull
{
    public int TotalCount { get; }

    public IEnumerable<T> Items { get; }

    public PagedList(int totalCount, IEnumerable<T> items)
    {
        TotalCount = totalCount;
        Items = items;
    }
}
