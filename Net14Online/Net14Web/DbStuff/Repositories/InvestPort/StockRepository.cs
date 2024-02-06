using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.InvestPort;

namespace Net14Web.DbStuff.Repositories
{
    public class StockRepository : BaseRepository<Stock>
    {
        public StockRepository(WebDbContext context) : base(context) { }

        public IEnumerable<Stock> GetStocks(int maxCount = 10)
        {
            return _entyties
                .Take(maxCount)
                .ToList();
        }


        public void UpdatePrice(int stockId, int price)
        {
            var stock = _entyties.First(x => x.Id == stockId);
            stock.Price = price;
            _context.SaveChanges();
        }
    }
}
