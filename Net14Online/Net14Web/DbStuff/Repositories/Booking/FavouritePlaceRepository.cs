using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.BookingWeb;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class FavouritePlaceRepository : BaseRepository<FavouritePlace>
    {
        public FavouritePlaceRepository(WebDbContext context) : base(context) { }


        public List<FavouritePlace> GetFavouritePlacesByUserId(int userId)
        {
            return _context.FavouritePlaces
                .Include(p => p.Users)
                .Where(p => p.Users.Any(u => u.Id == userId))
                .ToList();
        }
    }
}
