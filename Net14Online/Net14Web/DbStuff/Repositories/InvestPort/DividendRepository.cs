using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public class DividendRepository : BaseRepository<Dividend>
    {
        public DividendRepository(WebDbContext context) : base(context) { }

        
    }
}
