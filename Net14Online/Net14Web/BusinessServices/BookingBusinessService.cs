using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories.Booking;
using Net14Web.Models.BookingWeb;
using Net14Web.Services;
using Net14Web.Services.BookingPermissons;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Net14Web.DbStuff.Models.BookingWeb;
using Microsoft.EntityFrameworkCore;


namespace Net14Web.BusinessServices
{
    public class BookingBusinessService
    {
        private SearchRepository _searchRepository;
        private BookingPermission _bookingPermission;
        private FavouritePlaceRepository _favouritePlaceRepository;
        public AuthService _authService;
        public ClientBookingRepository _loginRepository;

        public BookingBusinessService(SearchRepository searchRepository, 
            BookingPermission bookingPermission, 
            FavouritePlaceRepository favouritePlaceRepository,
            AuthService authService,
            ClientBookingRepository loginRepository)
        {
            _searchRepository = searchRepository;
            _bookingPermission = bookingPermission;
            _favouritePlaceRepository = favouritePlaceRepository;
            _authService = authService;
            _loginRepository = loginRepository;
        }
        public List<SearchResultViewModel> GetSearches()
        {

            var searches = _searchRepository.GetSearchLoginConnection(10);

            var viewModels = searches.Select(search =>
            {
                return new SearchResultViewModel
                {
                    Id = search.Id,
                    Country = search.Country,
                    City = search.City,
                    CheckinDate = search.Checkin,
                    CheckoutDate = search.Checkout,
                    ClientEmail = search.ClientBooking.Email,
                    Owner = search.Owner?.Login ?? "Unknown",
                    CanDelete = _bookingPermission.CanDelete(search)
                };
            }).ToList();

            return viewModels;
        }

        public int AddSearch(IndexViewModel searchResultViewModel)
        {
            var login = _loginRepository.GetFirst();
            var search = new Search
            {
                Country = searchResultViewModel.Country,
                City = searchResultViewModel.City,
                Checkin = searchResultViewModel.CheckinDate,
                Checkout = searchResultViewModel.CheckoutDate,
                ClientBooking = login,
                Owner = _authService.GetCurrentUser()
            };

            return _searchRepository.Add(search);
        }
    }
}
