using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieBuilder _movieBuilder;
        private readonly ErrorBuilder _errorBuilder;
        private readonly UserBuilder _userBuilder;
        private readonly CommentBuilder _commentBuilder;
        private readonly RegistrationHelper _registrationHelper;

        private MoviesRepository _movieRepository;
        private UserRepository _userRepository;
        private CommentRepository _commentRepository;
        private AdminPanelViewModel _adminPanelViewModel;

        private static int activeUserId = -1;
        private const int COUNT_MOVIES_ON_INDEX = 10;

        public MoviesController(MovieBuilder movieBuilder, ErrorBuilder errorBuilder, UserBuilder userBuilder, CommentBuilder commentBuilder, 
            RegistrationHelper registrationHelper,
            MoviesRepository moviesRepository, UserRepository userRepository, CommentRepository commentRepository)
        {
            _movieBuilder = movieBuilder;
            _errorBuilder = errorBuilder;
            _userBuilder = userBuilder;
            _commentBuilder = commentBuilder;
            _registrationHelper = registrationHelper;
            _movieRepository = moviesRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _adminPanelViewModel = new AdminPanelViewModel();
            _adminPanelViewModel.Movies = _movieRepository.GetAll()
                .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m)).ToList();
            _adminPanelViewModel.Users = _userRepository.GetAll()
                .Select(u => userBuilder.RebuildUserToUserView(u)).ToList();
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {
            var movies = _movieRepository
                .GetMoviesAsync(COUNT_MOVIES_ON_INDEX)
                .Result
                .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m))
                .ToList();
            return View(movies);
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        public IActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }

        public IActionResult AdminPanel()
        {
            return View(_adminPanelViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel addMovie)
        {
            var movie = _movieBuilder.BuildMovie(addMovie);
            await _movieRepository.AddAsync(movie);
            return RedirectToAction("Movie", RedirectMovieById(movie.Id));
        }

        [HttpPost]
        public async Task<IActionResult> Registration(AddUserViewModel addUser)
        {
            if (!ModelState.IsValid)
            {
                return View(addUser);
            }

            var user = _userBuilder.BuildUser(addUser);
            await _userRepository.AddAsync(user);
            activeUserId = user.Id;
            return RedirectToAction("User", RedirectUserById(activeUserId));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            var user = await _userRepository.GetUserByLoginAndPasswordAsync(loginUser.Login, loginUser.Password);
            if (user != null)
            {
                activeUserId = user.Id;
                return RedirectToAction("User", RedirectUserById(activeUserId));
            }
            return View();
        }

        [HttpGet]
        public new async Task<IActionResult> User(int userId)
        {
            var user = await _userRepository.GetUserWithCommentsAsync(userId);
            if (user != null)
            {
                var userView = _userBuilder.RebuildUserToUserView(user);
                return View(userView);
            }
            return RedirectToAction("Error", _errorBuilder.BuildError("User", "The user was not found"));
        }

        [HttpGet]
        public async Task<IActionResult> Movie(int movieId)
        {
            var movie = await _movieRepository.GetMovieWithCommentsAsync(movieId);
            if (movie != null)
            {
                var movieView = _movieBuilder.RebuildMovieToMovieViewModel(movie);
                return View(movieView);
            }
            return RedirectToAction("Error", _errorBuilder.BuildError("Movie", "The movie was not found"));
        }

        [HttpPost]
        public async Task<IActionResult> AddCommentOnMovie(int movieId, string description)
        {
            if (activeUserId == -1)
            {
                return RedirectToAction("Movie", RedirectMovieById(movieId));
            }
            var timeOfWriting = DateTime.Now;
            var movie = _movieRepository.GetById(movieId);
            var user = _userRepository.GetById(activeUserId);
            var comment = _commentBuilder.BuildComment(timeOfWriting, description, user, movie);
            await _commentRepository.AddAsync(comment);
            return RedirectToAction("Movie", RedirectMovieById(movieId));
        }

        public async Task<IActionResult> RemoveCommentOnMovie(int commentId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId)!;
            var movieId = comment!.Movie.Id;
            await _commentRepository.DeleteAsync(commentId);
            return RedirectToAction("Movie", RedirectMovieById(movieId));
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            await _userRepository.DeleteAsync(userId);
            return RedirectToAction("AdminPanel");
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel editUser)
        {
            var user = await _userRepository.GetByIdAsync(editUser.Id)!;
            _userRepository.UpdateUser(user!, editUser);
            return RedirectToAction("AdminPanel");
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> EditMovie(MovieViewModel editMovie)
        {
            var movie = await _movieRepository.GetByIdAsync(editMovie.Id)!;
            _movieRepository.UpdateMovie(movie!, editMovie);
            return RedirectToAction("AdminPanel");
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyEmail(string email)
        {
            var emailExists = _registrationHelper.IsEmailExists(email);
            return Json(!emailExists);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyLogin(string login)
        {
            var loginExists = _registrationHelper.IsLoginExists(login);
            return Json(!loginExists);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyLoginAuthorization(string login)
        {
            var loginExists = _registrationHelper.IsLoginExists(login);
            return Json(loginExists);
        }

        public object RedirectMovieById(int id)
        {
            object movie = new { movieId = id };
            return movie;
        }

        public object RedirectUserById(int id)
        {
            object user = new { userId = id };
            return user;
        }
    }
}
