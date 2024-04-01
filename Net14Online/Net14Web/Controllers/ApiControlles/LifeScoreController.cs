using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.LifeScore;
using Net14Web.Services.LifeScore;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/api/lifescore/{action}")]
    public class LifeScoreController : Controller
    {
        private readonly TeamService _teamService;

        public LifeScoreController(TeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public List<TeamViewModel> GetTeams()
        {
            var teams = _teamService.GetTeams().Select(team => new TeamViewModel
            {
                Country = team.Country,
                Name = team.Name,
                Liga = team.Liga,
                ShortName = team.ShortName,
                Id = team.Id,
            }).ToList();
            return teams;
        }
    }
}
