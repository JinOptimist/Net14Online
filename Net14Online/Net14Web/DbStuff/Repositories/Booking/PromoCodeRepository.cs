using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.BookingWeb;
using System.Text;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class PromoCodeRepository : BaseRepository<PromoCode>
    {
        public PromoCodeRepository(WebDbContext context) : base(context) { }

        public string GeneratePromoCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            StringBuilder codeBuilder = new StringBuilder();

            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(chars.Length);
                char randomChar = chars[index];
                codeBuilder.Append(randomChar);
            }
            return codeBuilder.ToString();
        }
    }
}
