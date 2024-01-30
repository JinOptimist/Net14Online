
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.Repositories
{
    public class WeaponRepository : BaseRepository<Weapon>
    {
        public WeaponRepository(WebDbContext context) : base(context) { }
    }
}
