using Net14Web.DbStuff.Models.LifeScore;

namespace Net14Web.DbStuff.Repositories.LifeScore
{
    public class PlayerRepository: BaseRepository<Player>
    {
        public PlayerRepository(WebDbContext context) : base(context) { }


    }
}
