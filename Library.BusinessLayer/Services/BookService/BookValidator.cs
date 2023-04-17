using FluentValidation;
using Library.DomainLayer.Helpers;
using Library.DomainLayer.Models;
using System.Text.RegularExpressions;

namespace Library.BusinessLayer.Services.BookService
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.ISBN).NotNull().NotEmpty().Must(IsValidISBN);
            RuleFor(x => x.Title).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Author).MaximumLength(20);
            RuleFor(x => x.Description).MaximumLength(200);
        }

        private bool IsValidISBN(string isbn)
        {
            if (isbn.Length == 13)
            {
                if (Regex.IsMatch(isbn, Constants.ISBN10Pattern))
                    return true;
            }
            else if (isbn.Length == 17)
            {
                if (Regex.IsMatch(isbn, Constants.ISBN13Pattern))
                    return true;
            }
            return false;
        }
    }
}
