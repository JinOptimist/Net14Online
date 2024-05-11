using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Net14Web.DbStuff.Models.BookingWeb
{
    public class PromoCode : BaseModel
    {
        public string UniquePromoCode { get; set; }
        public int ClientBookingId { get; set; }
        public virtual ClientBooking ClientBooking { get; set; }
    }
}

