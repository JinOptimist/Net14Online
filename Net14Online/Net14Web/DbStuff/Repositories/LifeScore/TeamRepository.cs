using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Repositories.LifeScore
{
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository(WebDbContext context) : base(context) { }

        public List<Team> GetAllTeams()
        {
            return _entyties.Include(t => t.Games).ToList();
        }

        public void UpdateTeam(int id, Team updatedTeam)
        {
            var team = GetById(id);
            team.Players = updatedTeam.Players;
            team.Games = updatedTeam.Games;
            _context.SaveChanges();
        }
    }
}
