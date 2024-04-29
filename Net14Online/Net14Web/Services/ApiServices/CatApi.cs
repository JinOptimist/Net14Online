namespace Net14Web.Services.ApiServices
{
    public class CatApi
    {
        private HttpClient _httpClient;

        public CatApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<CatDto> GetRandomImageUrl()
        {
            return _httpClient.GetFromJsonAsync<CatDto[]>($"/v1/images/search")
                .ContinueWith(response => response.Result.FirstOrDefault());
        }
    }
}
