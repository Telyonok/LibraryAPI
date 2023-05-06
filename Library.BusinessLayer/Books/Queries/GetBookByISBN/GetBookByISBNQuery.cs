using Library.Domain.Models;
using MediatR;

namespace Library.Application.Books.Queries.GetBookByISBN;
public record GetBookByISBNQuery(string ISBN) : IRequest<Book>;
