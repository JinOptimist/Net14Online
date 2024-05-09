using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.BookingWeb;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class ClientBookingRepository: BaseRepository<ClientBooking>
    {
        public ClientBookingRepository(WebDbContext context): base(context) { }

        public IEnumerable<ClientBooking> GetLoginWithOwner(int maxCount = 10)
        {
            return _context.ClientsBooking
                .Include(x => x.Owner)
                .Take(maxCount)
                .ToList();
        }
        public void UpdateEmail(int clientId, string email)
        {
            var searches = _context.ClientsBooking.First(x => x.Id == clientId);
            searches.Email = email;
            _context.SaveChanges();
        }

        public ClientBooking? GetFirst()
        {
            return _context.ClientsBooking.FirstOrDefault();
        }
        public ClientBooking? GetUserByNameAndPassword(string name, string password)
        {
            return _entyties
                .FirstOrDefault(login => login.Name.ToLower() == name && login.Password == password);
        }
        public bool AnyUserWithName(string name)
        {
            return _entyties.Any(x => x.Name == name);
        }
    }
}
 


        
