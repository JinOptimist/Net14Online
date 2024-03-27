using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public class AlertRepository : BaseRepository<Alert>
    {
        public AlertRepository(WebDbContext context) : base(context) { }
    }
}
