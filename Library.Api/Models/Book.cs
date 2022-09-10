namespace Library.Api.Models;

public class Book
{
    public int Id { get; set; } 

    public string Title { get; set; }

    public List<int> AuthorsId { get; set; }
}
