using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.BookingWeb;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class SearchRepository : BaseRepository<Search>
    {
        public SearchRepository(WebDbContext context): base(context) { }

        public IEnumerable<Search> GetSearchLoginConnection(int maxCount  = 10)
        {
            return _context.Searches
                .Include(x => x.LoginBooking)
                .Take(maxCount)
                .ToList();    
        }

        public void UpdateCity(int searchId, string city)
        {
            var searches = _context.Searches.First(x => x.Id == searchId);
            searches.City = city;
            _context.SaveChanges();
        }

        public Search? GetFirst() 
        {
            return _context.Searches.FirstOrDefault();
        }

        }
}
