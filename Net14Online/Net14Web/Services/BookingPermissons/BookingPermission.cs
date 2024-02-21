using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.BookingWeb;
namespace Net14Web.Services.BookingPermissons
{
    public class BookingPermission
    {
        private AuthService _authService;

        public BookingPermission(AuthService authService)
            {
            _authService = authService;
            }
        public bool IsCurrentUserAdmin => _authService.IsAdmin();
        public bool CanDelete(Search search)
         => search.Owner is null
             || search.Owner?.Id == _authService.GetCurrentUserId()
             || IsCurrentUserAdmin;
    }
}
