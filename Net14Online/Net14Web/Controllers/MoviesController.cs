using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
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
        private readonly LoginHelper _loginHelper;
        private readonly MovieEditHelper _movieEditHelper;
        private readonly UserEditHelper _userEditHelper;

        public static AdminPanelViewModel AdminPanelViewModel = new AdminPanelViewModel();

        private WebDbContext _webDbContext;

        private static int activeUserId = -1;
        private const int COUNT_MOVIES_ON_INDEX = 10;

        public MoviesController(MovieBuilder movieBuilder, ErrorBuilder errorBuilder, UserBuilder userBuilder, CommentBuilder commentBuilder, 
            LoginHelper loginHelper, MovieEditHelper movieEditHelper, UserEditHelper userEditHelper,
            WebDbContext webDbContext)
        {
            _movieBuilder = movieBuilder;
            _errorBuilder = errorBuilder;
            _userBuilder = userBuilder;
            _commentBuilder = commentBuilder;
            _loginHelper = loginHelper;
            _movieEditHelper = movieEditHelper;
            _userEditHelper = userEditHelper;
            _webDbContext = webDbContext;
            AdminPanelViewModel.Movies = _webDbContext.Movies.
                Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m)).ToList();
            AdminPanelViewModel.Users = _webDbContext.Users.
                Select(u => userBuilder.RebuildUserToUserView(u)).ToList();
        }

        public IActionResult Index()
        {
            var movies = _webDbContext.Movies
                .Take(COUNT_MOVIES_ON_INDEX)
                .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m)).ToList();
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
            return View(AdminPanelViewModel);
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovieViewModel addMovie)
        {
            var movie = _movieBuilder.BuildMovie(addMovie);
            _webDbContext.Movies.Add(movie);
            _webDbContext.SaveChanges();
            return RedirectToAction("Movie", RedirectMovieById(movie.Id));
        }

        [HttpPost]
        public IActionResult Registration(AddUserViewModel addUser)
        {
            var user = _userBuilder.BuildUser(addUser);
            _webDbContext.Add(user);
            _webDbContext.SaveChanges();
            activeUserId = user.Id;
            return RedirectToAction("User", RedirectUserById(activeUserId));
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel loginUser)
        {
            var user = _loginHelper.FindLoggedUser(_webDbContext.Users.ToList(), loginUser);
            if (user != null)
            {
                activeUserId = user.Id;
                return RedirectToAction("User", RedirectUserById(activeUserId));
            }
            return View();
        }

        [HttpGet]
        public new IActionResult User(int userId)
        {
            var user = _webDbContext.Users
                .Include(u => u.Comments)
                .FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var userView = _userBuilder.RebuildUserToUserView(user);
                return View(userView);
            }
            return RedirectToAction("Error", _errorBuilder.BuildError("User", "The user was not found"));
        }

        [HttpGet]
        public IActionResult Movie(int movieId)
        {
            var movie = _webDbContext.Movies
                .Include(m => m.Comments)
                .FirstOrDefault(movie => movie.Id == movieId);
            if (movie != null)
            {
                var movieView = _movieBuilder.RebuildMovieToMovieViewModel(movie);
                return View(movieView);
            }
            return RedirectToAction("Error", _errorBuilder.BuildError("Movie", "The movie was not found"));
        }

        [HttpPost]
        public IActionResult AddCommentOnMovie(int movieId, string description)
        {
            if (activeUserId == -1)
            {
                return RedirectToAction("Movie", RedirectMovieById(movieId));
            }
            var timeOfWriting = DateTime.Now;
            var movie = _webDbContext.Movies.First(movie => movie.Id == movieId);
            var user = _webDbContext.Users.First(u => u.Id == activeUserId);
            var comment = _commentBuilder.BuildComment(timeOfWriting, description, user, movie);
            _webDbContext.Comments.Add(comment);
            _webDbContext.SaveChanges();
            return RedirectToAction("Movie", RedirectMovieById(movieId));
        }

        public IActionResult RemoveCommentOnMovie(int commentId)
        {
            var comment = _webDbContext.Comments.First(comment => comment.Id == commentId);
            var movieId = comment.Movie.Id;
            _webDbContext.Remove(comment);
            _webDbContext.SaveChanges();
            return RedirectToAction("Movie", RedirectMovieById(movieId));
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public IActionResult EditUser(UserViewModel editUser)
        {
            var user = _webDbContext.Users.First(user => user.Id == editUser.Id);
            _userEditHelper.EditUser(user, editUser);
            _webDbContext.SaveChanges();
            return RedirectToAction("AdminPanel");
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public IActionResult EditMovie(MovieViewModel editMovie)
        {
            var movie = _webDbContext.Movies.First(m => m.Id == editMovie.Id);
            _movieEditHelper.EditMovie(movie, editMovie);
            _webDbContext.SaveChanges();
            return RedirectToAction("AdminPanel");
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
