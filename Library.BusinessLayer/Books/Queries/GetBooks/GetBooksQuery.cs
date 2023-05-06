using Library.Domain.Models;
using MediatR;

namespace Library.Application.Books.Queries.GetBooks;
public record GetBooksQuery(): IRequest<IEnumerable<Book>>;