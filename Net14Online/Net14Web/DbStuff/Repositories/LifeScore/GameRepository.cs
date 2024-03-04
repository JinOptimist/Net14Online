using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Repositories.LifeScore
{
    public class GameRepository : BaseRepository<SportGame>
    {
        public GameRepository(WebDbContext dbContext): base(dbContext) { }

        public void AddSportGame(SportGame newSportGame)
        {
            _entyties.Add(newSportGame);
            _context.SaveChanges();
        }
    }
}
