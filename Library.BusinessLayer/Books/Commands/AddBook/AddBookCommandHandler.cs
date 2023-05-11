using FluentValidation;
using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Models;
using MediatR;
using Library.Domain.Helpers;

namespace Library.Application.Books.Commands.AddBook;
public class AddBookCommandHandler : IRequestHandler<AddBookCommand>
{
    private readonly ILibraryDbContext _context;
    private readonly IValidator<AddBookCommand> _validator;

    public AddBookCommandHandler(ILibraryDbContext context, IValidator<AddBookCommand> validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task Handle(AddBookCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);

        if (_context.Books.Any(b => b.ISBN == command.ISBN))
            throw new EntityAlreadyExistsException(string.Format(Constants.BookWithIsbnExistsMessage, command.ISBN));

        var book = new Book()
        {
            ISBN = command.ISBN,
            Title = command.Title,
            Genre = command.Genre,
            Description = command.Description,
            Author = command.Author,
            BorrowTime = DateTime.Now,
            ReturnTime = DateTime.Now.AddDays(14),
        };

        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
