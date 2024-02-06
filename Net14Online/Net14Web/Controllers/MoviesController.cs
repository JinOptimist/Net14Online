using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services;
using Net14Web.Services.Movies;
using System.Security.Claims;

namespace Net14Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieBuilder _movieBuilder;
        private readonly ErrorBuilder _errorBuilder;
        private readonly UserBuilder _userBuilder;
        private readonly CommentBuilder _commentBuilder;
        private readonly RegistrationHelper _registrationHelper;
        private readonly CreateFilePathHelper _createFilePathHelper;
        private readonly UploadFileHelper _uploadFileHelper;

        private MoviesRepository _movieRepository;
        private UserRepository _userRepository;
        private CommentRepository _commentRepository;
        private AuthService _authService;

        private AdminPanelViewModel _adminPanelViewModel;

        private static int _activeUserId = -1;
        private string _straightPathForUsers = "";
        private string _straightPathForMovies = "";

        private const int COUNT_MOVIES_ON_INDEX = 10;
        private const string DEFAULT_USER_AVATAR_PATH_FOR_DB = "/images/movies/userAvatars/";
        private const string DEFAULT_MOVIE_POSTER_PATH_FOR_DB = "/images/movies/moviePosters/";
        private const string DEFAULT_USER_AVATAR_NAME = "userAvatar_";
        private const string DEFAULT_MOVIE_POSTER_NAME = "moviePoster_";
        public const string AUTH_KEY = "MoviesKey";

        public MoviesController(MovieBuilder movieBuilder,
                                ErrorBuilder errorBuilder,
                                UserBuilder userBuilder,
                                CommentBuilder commentBuilder,
                                RegistrationHelper registrationHelper,
                                MoviesRepository moviesRepository,
                                UserRepository userRepository,
                                CommentRepository commentRepository,
                                CreateFilePathHelper createFilePathHelper,
                                UploadFileHelper uploadFileHelper,
                                AuthService authService)
        {
            _movieBuilder = movieBuilder;
            _errorBuilder = errorBuilder;
            _userBuilder = userBuilder;
            _commentBuilder = commentBuilder;
            _registrationHelper = registrationHelper;
            _movieRepository = moviesRepository;
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _createFilePathHelper = createFilePathHelper;
            _uploadFileHelper = uploadFileHelper;
            _adminPanelViewModel = new AdminPanelViewModel();
            _adminPanelViewModel.Movies = _movieRepository.GetAll()
                .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m)).ToList();
            _adminPanelViewModel.Users = _userRepository.GetAll()
                .Select(u => _userBuilder.RebuildUserToUserView(u)).ToList();
            _commentRepository = commentRepository;
            _straightPathForUsers = _createFilePathHelper.GetStraightPath("images", "movies", "userAvatars");
            _straightPathForMovies = _createFilePathHelper.GetStraightPath("images", "movies", "moviePosters");
            _authService = authService;
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

        [Authorize]
        public IActionResult AdminPanel()
        {
            return View(_adminPanelViewModel);
        }

        public async Task<IActionResult> UpdateUserAvatar(int userId, IFormFile avatar)
        {
            var extension = Path.GetExtension(avatar.FileName);
            var fileName = $"{DEFAULT_USER_AVATAR_NAME}{userId}{extension}";
            var path = _createFilePathHelper.GetCombinePath(_straightPathForUsers, fileName);
            await _uploadFileHelper.UploadFile(path, avatar);
            var urlPath = $"{DEFAULT_USER_AVATAR_PATH_FOR_DB}{fileName}";
            await _userRepository.UpdateAvatar(userId, urlPath);
            return RedirectToAction("User", RedirectUserById(userId));
        }

        public async Task<bool> SaveMoviePoster(IFormFile poster, string fileName)
        {
            var path = _createFilePathHelper.GetCombinePath(_straightPathForMovies, fileName);
            return await _uploadFileHelper.UploadFile(path, poster);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMovie(AddMovieViewModel addMovie)
        {
            var extension = Path.GetExtension(addMovie.Poster.FileName);
            var movie = _movieBuilder.BuildMovie(addMovie, "");
            var fileName = $"{DEFAULT_MOVIE_POSTER_NAME}{movie.Id}{extension}";
            if (await SaveMoviePoster(addMovie.Poster, fileName))
            {
                var urlPath = $"{DEFAULT_MOVIE_POSTER_PATH_FOR_DB}{fileName}";
                movie.PosterUrl = urlPath;
                await _movieRepository.AddAsync(movie);
                return RedirectToAction("Movie", RedirectMovieById(movie.Id));
            }
            return RedirectToAction("Error", _errorBuilder.BuildError("MovieAdd", "The movie wasn't added."));
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
            _activeUserId = user.Id;
            return RedirectToAction("User", RedirectUserById(_activeUserId));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUser)
        {
            var user = await _userRepository.GetUserByLoginAndPasswordAsync(loginUser.Login, loginUser.Password);
            if (user == null)
            {
                ModelState.AddModelError(nameof(LoginUserViewModel.Login), "Wrong name or passwrod");
                return View(loginUser);
            }

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Login.ToString()),
                new Claim("email", user.Email ?? ""),
            };

            var identity = new ClaimsIdentity(claims, AUTH_KEY);
            var principal = new ClaimsPrincipal(identity);
            HttpContext
                .SignInAsync(AUTH_KEY, principal)
                .Wait();

            _activeUserId = user.Id;

            return RedirectToAction("User", RedirectUserById(_activeUserId));
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync().Wait();
            return RedirectToAction("Index");
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
        [Authorize]
        public async Task<IActionResult> AddCommentOnMovie(int movieId, string description)
        {
            if (_activeUserId == -1)
            {
                return RedirectToAction("Movie", RedirectMovieById(movieId));
            }
            var timeOfWriting = DateTime.Now;
            var movie = await _movieRepository.GetByIdAsync(movieId)!;
            var user = await _userRepository.GetByIdAsync(_activeUserId)!;
            var comment = _commentBuilder.BuildComment(timeOfWriting, description, user, movie);
            await _commentRepository.AddAsync(comment);
            return RedirectToAction("Movie", RedirectMovieById(movieId));
        }

        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            await _userRepository.DeleteAsync(userId);
            return RedirectToAction("AdminPanel");
        }


        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveMovie(int movieId)
        {
            await _movieRepository.DeleteAsync(movieId);
            return RedirectToAction("AdminPanel");
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        [Authorize]
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
        [Authorize]
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
