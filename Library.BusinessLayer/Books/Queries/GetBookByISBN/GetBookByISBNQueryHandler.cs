using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Helpers;
using Library.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookByISBN;
public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, Book>
{
    private readonly ILibraryDbContext _context;

    public GetBookByISBNQueryHandler(ILibraryDbContext context)
    {
        _context = context;
    }

    public async Task<Book> Handle(GetBookByISBNQuery query, CancellationToken cancellationToken)
    {
        var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.ISBN == query.ISBN, cancellationToken);

        if (book is null)
            throw new EntityNotFoundException(string.Format(Constants.BookIsbnNotFoundMessage, query.ISBN));

        return book;
    }
}
