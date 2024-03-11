using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.PcShop;

namespace Net14Web.DbStuff.Repositories.PcShop
{
    public class PcsRepositoryPcShop
    {
        private WebDbContext _context;
        public PcsRepositoryPcShop(WebDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PCModel> GetPCs(int maxCount = 10)
        {
            return _context.PCModel.Include(x => x.CPU).Take(maxCount).ToList();
        }
    }
}