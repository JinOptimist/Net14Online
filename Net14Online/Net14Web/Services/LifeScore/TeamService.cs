using Net14Web.DbStuff.Models.LifeScore;
using Net14Web.DbStuff.Repositories.LifeScore;
using Net14Web.Models.LifeScore;

namespace Net14Web.Services.LifeScore
{
    public class TeamService
    {
        private readonly TeamRepository _repository;

        public TeamService(TeamRepository repository)
        {
            _repository = repository;
        }

        public List<Team> GetTeams()
        {
            var teams = _repository.GetAllTeams();

            return teams;
        }

        public Team GetTeamByName(string name)
        {
            var team = _repository.GetTeamByName(name);
            return team;
        }

        public List<Team> GetTeamsByLiga(string liga)
        {
            var teams = _repository.GetTeamsByLiga(liga);
            return teams;
        }

        public Team GetTeamByIdWithGames(int id)
        {
            var team = _repository.GetTeamByIdWithGames(id);
            return team;
        }

        public int CreateTeam(CreateTeamViewModel teamModel)
        {
            var newTeam = new Team
            {
                Country = teamModel.Country,
                Liga = teamModel.Liga,
                Name = teamModel.Name,
                ShortName = teamModel.ShortName,
            };

            var newTeamId = _repository.Add(newTeam);
            return newTeamId;
        }

        public void DeleteTeam(int teamId)
        {
            _repository.Delete(teamId);
        }
    }
}
