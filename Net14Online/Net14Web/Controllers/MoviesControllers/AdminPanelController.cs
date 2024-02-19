using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;
using Net14Web.Services.Movies.Permissions;

namespace Net14Web.Controllers.MoviesControllers
{
    public class AdminPanelController : Controller
    {
        private readonly AdminPanelPermissions _adminPanelPermissions;
        private readonly MovieBuilder _movieBuilder;
        private readonly UserBuilder _userBuilder;

        private MoviesRepository _movieRepository;
        private UserRepository _userRepository;

        private AdminPanelViewModel _adminPanelViewModel;

        public const int MAX_COUNT_USERS_ON_PAGE = 10;
        public const int MAX_COUNT_MOVIES_ON_PAGE = 10;

        public AdminPanelController(AdminPanelPermissions adminPanelPermissions, MoviesRepository movieRepository, UserRepository userRepository, MovieBuilder movieBuilder, UserBuilder userBuilder)
        {
            _adminPanelPermissions = adminPanelPermissions;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _movieBuilder = movieBuilder;
            _userBuilder = userBuilder;
            _adminPanelViewModel = new AdminPanelViewModel();
        }

        [Authorize]
        [Role(SeedExtentoin.ADMIN_ROLE, SeedExtentoin.MODERATOR_ROLE)]
        [Route("movies/adminpanel")]
        public IActionResult AdminPanel()
        {
            _adminPanelViewModel.CanAddMovie = _adminPanelPermissions.CanAddMovie();
            _adminPanelViewModel.CanUpdateMovie = _adminPanelPermissions.CanUpdateMovie();
            _adminPanelViewModel.CanDeleteMovie = _adminPanelPermissions.CanDeleteMovie();
            _adminPanelViewModel.CanUpdateUser = _adminPanelPermissions.CanUpdateUser();
            _adminPanelViewModel.CanDeleteUser = _adminPanelPermissions.CanDeleteUser();

            if (_adminPanelViewModel.CanDeleteMovie || _adminPanelViewModel.CanUpdateMovie)
            {
                _adminPanelViewModel.Movies = _movieRepository.GetAll()
                    .Take(MAX_COUNT_USERS_ON_PAGE)
                    .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m))
                    .ToList();
            }

            if (_adminPanelViewModel.CanUpdateUser || _adminPanelViewModel.CanDeleteUser)
            {
                _adminPanelViewModel.Users = _userRepository.GetAll()
                    .Take(MAX_COUNT_MOVIES_ON_PAGE)
                    .Select(u => _userBuilder.RebuildUserToUserView(u))
                    .ToList();
            }

            return View(_adminPanelViewModel);
        }

        [HttpPost]
        [Authorize]
        [Permission(PermissionType.DeleteUser)]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userRepository.DeleteAsync(userId);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [Authorize]
        [Permission(PermissionType.DeleteMovie)]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            await _movieRepository.DeleteAsync(movieId);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [Authorize]
        [Permission(PermissionType.EditUser)]
        public async Task<IActionResult> EditUser(UserViewModel editUser)
        {
            var user = await _userRepository.GetByIdAsync(editUser.Id)!;
            await _userRepository.UpdateUserAsync(user!, editUser);
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        [Authorize]
        [Permission(PermissionType.EditMovie)]
        public async Task<IActionResult> EditMovie(MovieViewModel editMovie)
        {
            var movie = await _movieRepository.GetByIdAsync(editMovie.Id)!;
            await _movieRepository.UpdateMovieAsync(movie!, editMovie);
            return RedirectToAction("AdminPanel");
        }
    }
}
