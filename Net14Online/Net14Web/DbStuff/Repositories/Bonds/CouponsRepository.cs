using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.Bonds;

namespace Net14Web.DbStuff.Repositories
{
    public class CouponsRepository : BaseRepository<Coupon>
    {
        public CouponsRepository(WebDbContext context) : base(context) { }
        public IEnumerable<Coupon> GetCoupons(int maxCount = 10)
        {
            return _context
                .Coupons
                .Include(x => x.Bond)
                .Include(x => x.Bond.Owner)
                .Take(maxCount)
                .ToList();
        }
        public Coupon GetByIdWithOwner(int couponId)
        {
            return _entyties
                .Include(x => x.Bond)
                .Include(x => x.Bond.Owner)
                .First(x => x.Id == couponId);
        }
    }
}
