using Library.Application.Interfaces;
using Library.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Queries.GetBooks;
public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<Book>>
{
    private readonly ILibraryDbContext _context;

    public GetBooksQueryHandler(ILibraryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        var books = await _context.Books.AsNoTracking().ToListAsync(cancellationToken);
        return books;
    }
}
