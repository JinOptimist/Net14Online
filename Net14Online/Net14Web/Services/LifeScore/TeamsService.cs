using Net14Web.DbStuff.Models.LifeScore;
using Net14Web.DbStuff.Repositories.LifeScore.Repositories;
using Net14Web.Models.LifeScore;

namespace Net14Web.Services.LifeScore
{
    public class TeamsService: ITeamsService
    {
        private readonly ILifeScoreGenericRepository<Team> _repository;

        public TeamsService(ILifeScoreGenericRepository<Team> repository)
        {
            _repository = repository;
        }

        public async Task<TeamViewModel> CreateAsync(TeamViewModel team)
        {
            var newTeam = new Team
            {
                Country = team.Country,
                Liga = team.Liga,
                Name = team.Name,
                ShortName = team.ShortName,
            };

            newTeam = await _repository.CreateAsync(newTeam);

            team.Id = newTeam.Id;

            return team;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeamViewModel>> GetAllAsync()
        {
           var teams = await _repository.GetAllAsync();
           
            return teams.Select(x=> new TeamViewModel 
            {
                Country = x.Country,
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName,
                Liga = x.Liga,
                //Players = x.Players.Select(p=> new PlayerViewModel
                //                    {
                //                        Id = p.Id,
                //                        Assists =p.Assists,
                //                        FirstName = p.FirstName,
                //                        LastName = p.LastName,
                //                        Goals = p.Goals,
                //                        Team = p.Team.Name
                //                    }).ToList(),
            }).ToList();
        }

        public Task<TeamViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeamViewModel> UpdateAsync(TeamViewModel team)
        {
            throw new NotImplementedException();
        }
    }
}
