using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.BookingWeb;
using Net14Web.DbStuff.Repositories.Booking;
using System.Diagnostics;
namespace Net14Web.Services.BookingPermissons
{
    public class BookingPermission
    {
        private AuthService _authService;
        private SearchRepository _searchRepository;

        public BookingPermission(AuthService authService, SearchRepository searchRepository)
        {
            _authService = authService;
            _searchRepository = searchRepository;
        }
        public bool IsCurrentUserAdmin => _authService.IsAdmin();
        public bool CanDelete(Search search)
         => search.Owner is null
             || search.Owner?.Id == _authService.GetCurrentUserId()
             || IsCurrentUserAdmin;

        public bool CanChooseFavouritePlaces()
        {
            var user = _authService.GetCurrentUser();
            var userSearches = _searchRepository.GetSearchWithUser(user.Id);

            if (user != null && userSearches.Count() > 5)
            {
                return true;
            }
            return false;
        }
    }
}
