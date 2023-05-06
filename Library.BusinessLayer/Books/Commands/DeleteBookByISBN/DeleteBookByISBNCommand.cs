using MediatR;

namespace Library.Application.Books.Commands.DeleteBookByISBN;
public record DeleteBookByISBNCommand(string isbn) : IRequest;