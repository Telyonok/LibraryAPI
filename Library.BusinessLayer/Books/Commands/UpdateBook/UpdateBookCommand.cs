using MediatR;

namespace Library.Application.Books.Commands.UpdateBook;
public record UpdateBookCommand(int Id, string Title, string Genre, string Description, string Author) : IRequest;

