namespace Net14Web.Services.ApiServices
{
    public class DogApi
    {
        private HttpClient _httpClient;

        public DogApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<DogDto?> GetRandomDogUrl()
        {
            return _httpClient.GetFromJsonAsync<DogDto>($"/api/breeds/image/random");
        }
    }
}
