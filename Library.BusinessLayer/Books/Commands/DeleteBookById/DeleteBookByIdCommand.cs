using MediatR;

namespace Library.Application.Books.Commands.DeleteBookById;
public record DeleteBookByIdCommand(int Id) : IRequest;
