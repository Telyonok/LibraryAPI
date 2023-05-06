namespace Library.Web.Models;

public class BookResponse
{
    public string ISBN { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public DateTime BorrowTime { get; set; }
    public DateTime ReturnTime { get; set; }
}
