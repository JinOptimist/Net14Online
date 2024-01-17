using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace Net14Web.Models.BookingWeb
{
    public class SearchResultViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int CheckinDate { get; set; }
        public int CheckoutDate { get; set; }
    }
}
