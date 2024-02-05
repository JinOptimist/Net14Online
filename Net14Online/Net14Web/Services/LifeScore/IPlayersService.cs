using Net14Web.Models.LifeScore;

namespace Net14Web.Services.LifeScore
{
    public interface IPlayersService
    {
        Task<List<PlayerViewModel>> GetAllAsync();
        Task<PlayerViewModel> GetAsync(int id);
        Task<PlayerViewModel> CreateAsync(PlayerViewModel team);
        Task<PlayerViewModel> UpdateAsync(PlayerViewModel team);
        Task DeleteAsync(int id);
    }
}