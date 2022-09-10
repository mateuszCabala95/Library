namespace Library.Api.Helpers;

public class UserHelpers
{
    private readonly IHttpClientFactory _clientFactory;
    public UserHelpers(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<bool> IsUserLogin(string name, string jwt)
    {
        var url = $"https://localhost:7236/api/Auth/isvalid/{name}";
        var httpClient = new HttpClient();
        var response = await httpClient.PostAsJsonAsync(url, jwt);
        return response.IsSuccessStatusCode;
    }

}