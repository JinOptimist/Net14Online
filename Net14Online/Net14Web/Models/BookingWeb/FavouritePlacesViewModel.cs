using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.DbStuff.Models.BookingWeb;
using Net14Web.DbStuff.Models.Movies;
using RESTCountries.NET.Models;

namespace Net14Web.Models.BookingWeb
{
    public class FavouritePlacesViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public bool CanChooseFavouritePlaces { get; set; }  

        public List<SelectListItem> AllPlaces { get; set; }

        public List<FavouritePlace> UserFavouritePlaces { get; set; }

    }
}
