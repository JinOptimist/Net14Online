using Net14Web.DbStuff.Models.LifeScore;
using Net14Web.DbStuff.Repositories.LifeScore.Repositories;
using Net14Web.Models.LifeScore;

namespace Net14Web.Services.LifeScore
{
    public class PlayersService : IPlayersService
    {
        private readonly ILifeScoreGenericRepository<Player> _repository;

        public PlayersService(ILifeScoreGenericRepository<Player> repository)
        {
            _repository = repository;
        }

        public Task<PlayerViewModel> CreateAsync(PlayerViewModel player)
        {
            var newPlayer = new Player
            {

            };
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PlayerViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerViewModel> UpdateAsync(PlayerViewModel team)
        {
            throw new NotImplementedException();
        }
    }
}
