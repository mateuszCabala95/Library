using Library.Api.Models;

namespace Library.Api.Seeds;

public static class Seeds
{
    public static List<Author> Authors = new List<Author>
    {
        new Author
        {
            Id = 1,
            FirstName = "Remigiusz",
            LastName = "Mróz"
        },
        new Author
        {
            Id = 2,
            FirstName = "Brian",
            LastName = "Ward"
        }
    };

    public static List<Book> Books = new List<Book>
    {
        new Book
        {
            Id = 1,
            Title = "Jak działa linux",
            AuthorsId = new List<int> { 1 }
        },
        new Book
        {
            Id = 2,
            Title = "Aktywne wykrywanei zagrożeń",
            AuthorsId = new List<int>(){1,2}
        },
        
        new Book
        {
            Id = 3,
            Title = "VBA dla Excela",
            AuthorsId = new List<int>(){2}
        }
        
    };
}