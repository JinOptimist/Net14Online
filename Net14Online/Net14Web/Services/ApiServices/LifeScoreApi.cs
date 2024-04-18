using Net14Web.Services.ApiServices.Dtos.LifeScore;
using System.Text.Json.Nodes;

namespace Net14Web.Services.ApiServices
{
    public class LifeScoreApi
    {
        private readonly HttpClient _httpClient;

        public LifeScoreApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetLeagues()
        {

             var res = await _httpClient.GetFromJsonAsync<RootDto>($"/leagues");

            return "";
        }
    }
}
