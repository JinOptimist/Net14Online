using Microsoft.VisualBasic;

namespace Net14Web.Models.BookingWeb
{
    public class IndexViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateFormat CheckinDate  { get; set; }
        public DateFormat CheckoutDate { get; set; }
    }
}
