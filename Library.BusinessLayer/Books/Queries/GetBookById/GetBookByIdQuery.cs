using Library.Domain.Models;
using MediatR;

namespace Library.Application.Books.Queries.GetBookById;
public record GetBookByIdQuery(int Id) : IRequest<Book>;

