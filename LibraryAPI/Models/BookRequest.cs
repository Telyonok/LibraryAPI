namespace LibraryAPI.Models
{
    public class BookRequest
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
