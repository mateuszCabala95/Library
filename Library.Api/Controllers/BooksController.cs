using Library.Api.Dto;
using Library.Api.Helpers;
using Library.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController: ControllerBase
{
    private readonly UserHelpers _userHelpers;
    public BooksController(IHttpClientFactory clientFactory)
    {
        _userHelpers = new UserHelpers(clientFactory);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(Seeds.Seeds.Books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var book = Seeds.Seeds.Books.FirstOrDefault(x => x.Id == id);

        if (book is null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookDto dto)
    {
        var name = Request.Headers["user-name"].FirstOrDefault();
        var isUserLogin = await _userHelpers.IsUserLogin(name ?? "string", "someRandomJwt");
        if (!isUserLogin) return BadRequest("You are not logged in");

        var lastbook = Seeds.Seeds.Books.LastOrDefault();

        Book newBook = new Book
        {
            Id = lastbook?.Id + 1 ?? 1,
            Title = dto.Title,
            AuthorsId = dto.AuthorsId
        };

        Seeds.Seeds.Books.Add(newBook);
        
        return CreatedAtAction(nameof(GetOne), new { id = newBook.Id }, newBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var name = Request.Headers["user-name"].FirstOrDefault();
        var isUserLogin = await _userHelpers.IsUserLogin("string", "someRandomJwt");
        if (!isUserLogin) return BadRequest("You are not logged in");
        
        var existBook = Seeds.Seeds.Books.FirstOrDefault(x => x.Id == id);
        if (existBook is null) return NotFound();

        Seeds.Seeds.Books.Remove(existBook);

        return NoContent();
    }
}