using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Bonds;

namespace Net14Web.Services.BondServices
{
    public class BondPermissions
    {
        private AuthService _authService;

        public BondPermissions(AuthService authService)
        {
            _authService = authService;
        }
        public bool IsCurrentUserAdmin => _authService.IsAdmin();
        public bool CanDelete(Bond bond)
            => bond.Owner is null
                || bond.Owner?.Id == _authService.GetCurrentUserId() || IsCurrentUserAdmin;

    }
}
