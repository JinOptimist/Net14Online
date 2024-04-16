namespace RealEstateNet14Web.Services.ApiServices;

public class ExchangeRatesApi
{
    private HttpClient _httpClient;

    public ExchangeRatesApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<List<ExchangeRatesDto?>> GetExchangeRates(string code)
    {
        return  _httpClient.GetFromJsonAsync<List<ExchangeRatesDto>>("/exrates/rates?periodicity=0");
    }
    
}