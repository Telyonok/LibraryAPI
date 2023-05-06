using FluentValidation; 
using Library.Domain.Helpers;
using System.Text.RegularExpressions;

namespace Library.Application.Books.Commands.UpdateBook;
public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(x => x.Author).MaximumLength(20);
        RuleFor(x => x.Genre).MaximumLength(20);
        RuleFor(x => x.Description).MaximumLength(200);
    }
}
