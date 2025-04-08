﻿using D20Tek.Bookshelf.Web.Domain;

namespace D20Tek.Bookshelf.Web.Features.Books;

internal interface IBooksService
{
    public Task<BookEntity[]> GetAll();

    public Task<Result<BookEntity>> GetById(string id);
}
