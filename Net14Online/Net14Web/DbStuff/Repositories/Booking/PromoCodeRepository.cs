using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models.BookingWeb;
using System.Text;

namespace Net14Web.DbStuff.Repositories.Booking
{
    public class PromoCodeRepository : BaseRepository<PromoCode>
    {
        public PromoCodeRepository(WebDbContext context) : base(context) { }

    }
}
