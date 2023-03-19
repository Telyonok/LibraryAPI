using FluentValidation;
using Library.Domain.Models;
using System.Text.RegularExpressions;

namespace LibraryAPI.Helpers
{
    public class BookRequestValidator : AbstractValidator<BookRequest>
    {
        const string ISBN10Pattern = @"^\d-\d{4}-\d{4}-\d$";
        const string ISBN13Pattern = @"^\d{3}-\d-\d{4}-\d{4}-\d$";

        public BookRequestValidator()
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
                if (Regex.IsMatch(isbn, ISBN10Pattern))
                    return true;
            }
            else if (isbn.Length == 17)
            {
                if (Regex.IsMatch(isbn, ISBN13Pattern))
                    return true;
            }
            return false;
        }
    }
}
