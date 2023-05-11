using Library.Domain.Models;
using MediatR;

namespace Library.Application.Books.Commands.AddBook;
public record AddBookCommand
    (string ISBN, string Title, string Genre, string Description, string Author) : IRequest;
