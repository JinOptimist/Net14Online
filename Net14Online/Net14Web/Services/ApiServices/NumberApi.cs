namespace Net14Web.Services.ApiServices
{
    public class NumberApi
    {
        private HttpClient _httpClient;

        public NumberApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<string> GetFactAboutNumber(int number = 42)
        {
            return _httpClient.GetStringAsync($"/{number}");
        }

        public Task<string> GetMathFactAboutNumber(int number = 42)
        {
            return _httpClient.GetStringAsync($"/{number}/math");
        }
    }
}
