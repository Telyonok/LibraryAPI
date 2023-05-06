using Library.Application.Interfaces;
using Library.Application.Exceptions;
using MediatR;
using Library.Domain.Helpers;

namespace Library.Application.Books.Commands.DeleteBookById;
public class DeleteBookByISBNCommandHandler : IRequestHandler<DeleteBookByIdCommand>
{
    private readonly ILibraryDbContext _context;

    public DeleteBookByISBNCommandHandler(ILibraryDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBookByIdCommand command, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FindAsync(command.Id, cancellationToken);

        if (book is null)
            throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, command.Id));

        _context.Books.Remove(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
