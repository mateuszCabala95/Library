using System.Text.Json;
using Library.Api.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController: ControllerBase
{
    private IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    public AuthController(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserDto dto)
    {
        var url = "https://localhost:7236/api/Auth/register";
        var httpClient = new HttpClient();
        var response = await httpClient.PostAsJsonAsync(url, dto);
        if (response.IsSuccessStatusCode)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginASync(UserDto dto)
    {
        var url = "https://localhost:7236/api/Auth/login";
        var httpClient = new HttpClient();
        var response = await httpClient.PostAsJsonAsync(url, dto);
        if (response.IsSuccessStatusCode) return BadRequest(response.Content);
        return Ok(response.Content);
    }
}