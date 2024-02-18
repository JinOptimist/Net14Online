namespace Net14Web.Services.Movies.Permissions
{
    public class UserPermissions
    {
        private AuthService _authService;

        public UserPermissions(AuthService authService)
        {
            _authService = authService;
        }

        public bool CanUpdateAvatarUser(int userId)
            => _authService.GetCurrentUserId() == userId;
    }
}
