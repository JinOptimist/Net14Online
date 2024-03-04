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
    }
}
