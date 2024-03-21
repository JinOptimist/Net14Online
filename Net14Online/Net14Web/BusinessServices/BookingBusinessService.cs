using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories.Booking;
using Net14Web.Models.BookingWeb;
using Net14Web.Services;
using Net14Web.Services.BookingPermissons;


namespace Net14Web.BusinessServices
{
    public class BookingBusinessService
    {
        private SearchRepository _searchRepository;
        private BookingPermission _bookingPermission;
        public AuthService _authService;

        public BookingBusinessService(SearchRepository searchRepository, BookingPermission bookingPermission, AuthService authService)
        {
            _searchRepository = searchRepository;
            _bookingPermission = bookingPermission;
            _authService = authService;
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
                    LoginEmail = search.ClientBooking.Email,
                    Owner = search.Owner?.Login ?? "Unknown",
                    CanDelete = _bookingPermission.CanDelete(search)
                };
            }).ToList();

            return viewModels;
        }
    }
}
