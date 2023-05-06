using FluentValidation;
using Library.Application.Exceptions;
using Library.Application.Interfaces;
using Library.Domain.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Books.Commands.UpdateBook;
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly ILibraryDbContext _context;
    private readonly IValidator<UpdateBookCommand> _validator;

    public UpdateBookCommandHandler(ILibraryDbContext context, IValidator<UpdateBookCommand> validator)
    {
        _context = context;
        _validator = validator;
    }

    public async Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == command.Id);

        if (book is null)
            throw new EntityNotFoundException(string.Format(Constants.BookIdNotFoundMessage, command.Id));

        book.Title = command.Title;
        book.Description = command.Description;
        book.Author = command.Author;
        book.Genre = command.Genre;

        _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
