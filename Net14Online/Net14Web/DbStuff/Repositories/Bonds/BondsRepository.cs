﻿using Net14Web.DbStuff.Models.Bonds;

namespace Net14Web.DbStuff.Repositories
{
    public class BondsRepository : BaseRepository<Bond>
    {
        public BondsRepository(WebDbContext context) : base(context) { }

        public IEnumerable<Bond> GetBonds(int maxCount = 10)
        {
            return _context
                .Bonds
                .Take(maxCount)
                .ToList();
        }
        public void UpdatePrice(int id, int price)
        {
            var bond = _context.Bonds.First(x => x.Id == id);
            bond.Price = price;
            _context.SaveChanges();
        }
    }
}
