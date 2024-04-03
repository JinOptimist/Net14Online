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

        public async Task<List<LeagueDto?>> GetLeagues()
        {

             var res = await _httpClient.GetAsync("https://v1.hockey.api-sports.io/leagues");

              // var leagues = JsonArray.Parse<List<LeagueDto>>(res.["response"]);
            return new List<LeagueDto?>();
        }
    }
}
