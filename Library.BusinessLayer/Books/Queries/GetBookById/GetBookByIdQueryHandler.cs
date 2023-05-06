using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Helpers;
using Library.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBookById;
public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
{
    private readonly ILibraryDbContext _context;

    public GetBookByIdQueryHandler(ILibraryDbContext context)
    {
        _context = context;
    }

    public async Task<Book> Handle(GetBookByIdQuery query, CancellationToken cancellationToken)
    {
        var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == query.Id);

        if (book is null)
            throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, query.Id));

        return book;
    }
}
