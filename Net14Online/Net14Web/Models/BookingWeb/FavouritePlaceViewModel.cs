using Microsoft.AspNetCore.Mvc.Rendering;
using RESTCountries.NET.Models;

namespace Net14Web.Models.BookingWeb
{
    public class FavouritePlaceViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
