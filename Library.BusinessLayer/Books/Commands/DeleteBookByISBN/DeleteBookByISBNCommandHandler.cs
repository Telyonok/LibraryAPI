using Library.Application.Interfaces;
using Library.Application.Exceptions;
using MediatR;
using Library.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.DeleteBookByISBN;
public class DeleteBookByISBNCommandHandler : IRequestHandler<DeleteBookByISBNCommand>
{
    private readonly ILibraryDbContext _context;

    public DeleteBookByISBNCommandHandler(ILibraryDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBookByISBNCommand command, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstAsync(x => x.ISBN == command.isbn);

        if (book is null)
            throw new EntityNotFoundException(string.Format(Constants.BookIsbnNotFoundMessage, command.isbn));

        _context.Books.Remove(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
