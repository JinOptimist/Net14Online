using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.BookingWeb;
using System.Text;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class ClientBookingRepository: BaseRepository<ClientBooking>
    {
        public ClientBookingRepository(WebDbContext context): base(context) { }

        public IEnumerable<ClientBooking> GetLoginWithOwner(int maxCount = 10)
        {
            return _context.ClientsBooking
                .Include(x => x.Owner)
                .Include(x => x.PromoCode)
                .Take(maxCount)
                .ToList();
        }

        public ClientBooking? GetUserWithPromocodeById(int id)
        {
            return _context.ClientsBooking.Include(x => x.PromoCode).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateEmail(int loginId, string email)
        {
            var searches = _context.ClientsBooking.First(x => x.Id == loginId);
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

        public void GeneratePromoCode(ClientBooking? user)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var codeBuilder = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(chars.Length);
                char randomChar = chars[index];
                codeBuilder.Append(randomChar);
            }
            var code = new PromoCode
            {
                UniquePromoCode = codeBuilder.ToString(),
                ClientBooking = user,
            };
            user.PromoCode = code;
            _context.SaveChanges();
        }
    }
}
 


        
