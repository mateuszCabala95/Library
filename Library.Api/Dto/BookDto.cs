using System.ComponentModel.DataAnnotations;

namespace Library.Api.Dto;

public class BookDto
{
    [Required]
    public String Title { get; set; }
    [Required]
    public List<int> AuthorsId { get; set; }
}