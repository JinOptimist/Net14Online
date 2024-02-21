using Net14Web.DbStuff.Models.Movies;
namespace Net14Web.DbStuff.Models.BookingWeb

{
    public class Search : BaseModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public virtual User? Owner { get; set; }
        public virtual ClientBooking ClientBooking { get; set; }

    }
}
