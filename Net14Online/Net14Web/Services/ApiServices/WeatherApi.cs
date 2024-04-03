namespace Net14Web.Services.ApiServices
{
    public class WeatherApi
    {
        private HttpClient _httpClient;

        public WeatherApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<WeatherDto?> GetWeatherByCoordinate(string latitude = "55.53", string longitude = "27.23")
        {
            return _httpClient.GetFromJsonAsync<WeatherDto>(
                $"/v1/forecast?latitude={latitude}&longitude={longitude}&current=temperature_2m&hourly=temperature_2m");
        }
    }
}
