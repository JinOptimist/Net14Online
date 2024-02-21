using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace Net14Web.Models.BookingWeb
{
    public class SearchResultViewModel
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public string? UserName { get; set; }
        public string? Owner { get; set; }
        public bool CanDelete { get; set; }
        public string? LoginEmail { get; set; }
    }
}
