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

        public List<Team> GetTeamsByLiga(string liga)
        {
            return _entyties.Include(t => t.Games).Where(t => t.Liga == liga).ToList();
        }

        public Team GetTeamByName(string name)
        {
            return _entyties.First(t => t.Name == name);
        }

        public Team GetTeamByIdWithGames(int id)
        {
            return _entyties.Include(t => t.Games).First(t => t.Id == id);
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
