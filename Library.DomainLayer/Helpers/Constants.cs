namespace Library.DomainLayer.Helpers
{
    public class Constants
    {
        public const string UserWrongCredentialsMessage = "Invalid credentials.";
        public const string BookNotFoundMessage = "No matching book found.";
        public const string BookIdNotFoundMessage = "No book with provided ID:{0} found.";
        public const string BookIsbnNotFoundMessage = "No book with provided ISBN:{0} found.";
        public const string BookWithIsbnExistsMessage = "Book with provided ISBN:{0} already exists.";
        public const string BookInvalidMessage = "Invalid book parameters:";
        public const string UnknownErrorMessage = "Something went wrong";
        public const string TokenKey = "X-Access-Value";
        public const string ISBN10Pattern = @"^\d-\d{4}-\d{4}-\d$";
        public const string ISBN13Pattern = @"^\d{3}-\d-\d{4}-\d{4}-\d$";
    }
}
