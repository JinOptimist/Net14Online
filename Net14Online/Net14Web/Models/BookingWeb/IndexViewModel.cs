using Microsoft.VisualBasic;

namespace Net14Web.Models.BookingWeb
{
    public class IndexViewModel
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime CheckinDate  { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
