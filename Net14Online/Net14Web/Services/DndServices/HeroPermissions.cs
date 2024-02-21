using Net14Web.DbStuff.Models;

namespace Net14Web.Services.DndServices
{
    public class HeroPermissions
    {
        private AuthService _authService;

        public HeroPermissions(AuthService authService)
        {
            _authService = authService;
        }

        public bool IsCurrentUserAdmin => _authService.IsAdmin();

        //public bool CanDelete(Hero hero)
        //{
        //    return hero.Owner is null || hero.Owner?.Id == _authService.GetCurrentUserId();
        //}
        public bool CanDelete(Hero hero)
            => hero.Owner is null 
                || hero.Owner?.Id == _authService.GetCurrentUserId()
                || IsCurrentUserAdmin;

        public bool CanChooseFavoriteWeapon()
            => _authService.GetCurrentUser()?.Roles?.Any(r => r.Name == "dm") ?? false;
    }
}
