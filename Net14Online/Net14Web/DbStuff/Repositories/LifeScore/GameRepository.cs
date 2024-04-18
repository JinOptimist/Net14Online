using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Repositories.LifeScore
{
    public class GameRepository : BaseRepository<SportGame>
    {
        public GameRepository(WebDbContext dbContext) : base(dbContext) { }

        public void AddSportGame(SportGame newSportGame)
        {
            _entyties.Add(newSportGame);
            _context.SaveChanges();
        }

        public SportGame GetSportGame(int id)
        {
            return _entyties.Include(x => x.Teams).First(x => x.Id == id);
        }

        public void UpdateSportGame(SportGame game)
        {
            _entyties.Update(game);
            _context.SaveChanges();
        }
    }
}
