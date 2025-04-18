﻿namespace D20Tek.Bookshelf.Web.Features.Books;

public partial class BookListFilters
{
    public string _author = string.Empty;
    public string _editionCode = string.Empty;
    public string _mediaType = string.Empty;
    private bool isExpanded = false;
    private IEnumerable<string> _authors = [];
    private IEnumerable<string> _mediatypes = [];

    [Parameter]
    public EventCallback<BookQuery> SearchClicked { get; set; }

    protected override void OnInitialized()
    {
        _authors = _bookService.GetAuthors();
        _mediatypes = _bookService.GetMediaTypes();
    }

    private void ToggleExpanded() => isExpanded = !isExpanded;

    private async Task Search() =>
        await SearchClicked.InvokeAsync(new(_author, _editionCode, _mediaType, 0, 0));

    private void ResetFilters()
    {
        _author = string.Empty;
        _editionCode = string.Empty;
        _mediaType = string.Empty;
    }
}
