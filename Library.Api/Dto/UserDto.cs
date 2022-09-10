using System.ComponentModel.DataAnnotations;

namespace Library.Api.Dto;

public class UserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}