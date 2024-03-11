using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Bonds;

namespace Net14Web.Services.BondServices
{
    public class CouponPermissions
    {
        private AuthService _authService;

        public CouponPermissions(AuthService authService)
        {
            _authService = authService;
        }
        public bool IsCurrentUserAdmin => _authService.IsAdmin();
        public bool CanDelete(Coupon coupon)
            => coupon.Bond.Owner is null
                || coupon.Bond.Owner?.Id == _authService.GetCurrentUserId() || IsCurrentUserAdmin;

    }
}
