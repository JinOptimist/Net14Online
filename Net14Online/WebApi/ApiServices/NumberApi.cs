namespace WebApi.ApiServices;

public class NumberApi
{
    private HttpClient _httpClient;

    public NumberApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<string> GetFactNumber(int number)
    {
        return _httpClient.GetStringAsync($"/{number}");
    }
}