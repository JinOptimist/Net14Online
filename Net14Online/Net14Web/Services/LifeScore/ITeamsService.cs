using Net14Web.Models.LifeScore;

namespace Net14Web.Services.LifeScore
{
    public interface ITeamsService
    {
        Task<List<TeamViewModel>> GetAllAsync();
        Task<TeamViewModel> GetAsync(int id);
        Task<TeamViewModel> CreateAsync(TeamViewModel team);
        Task<TeamViewModel> UpdateAsync(TeamViewModel team);
        Task DeleteAsync(int id);
    }
}
