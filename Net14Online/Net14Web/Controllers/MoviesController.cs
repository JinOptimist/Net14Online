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

        /*    public static List<UserViewModel> Users = new List<UserViewModel>();
            public static List<MovieViewModel> Movies = new List<MovieViewModel>();*/
        public static AdminPanelViewModel AdminPanelViewModel = new AdminPanelViewModel();

        private WebDbContext _webDbContext;

        private static int activeUserId = -1;

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
            AdminPanelViewModel.Movies = _movieBuilder.RebuildMoviesToMoviesViewModel(_webDbContext.Movies.ToList());
            AdminPanelViewModel.Users = _userBuilder.RebuildUsersToUrsesViewModel(_webDbContext.Users.ToList());
        }

        public IActionResult Index()
        {
            var movies = _movieBuilder.RebuildMoviesToMoviesViewModel(_webDbContext.Movies.ToList());
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
            var user = _webDbContext.Users.FirstOrDefault(u => u.Id == userId);
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
            var movie = _webDbContext.Movies.FirstOrDefault(movie => movie.Id == movieId);
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

            /*var movie = _webDbContext.Movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movie != null)
            {
                var timeOfWriting = DateTime.Now;
                var user = Users[activeUserId];
                var movieComment = _commentBuilder.BuildCommentToMovie(timeOfWriting, description, user);
                var userComment = _commentBuilder.BuildCommentToUser(timeOfWriting, description, movie);
                movie.Comments.Add(movieComment);
                user.Comments.Add(userComment);
            }*/
            return RedirectToAction("Movie", RedirectMovieById(movieId));
        }

        [HttpPost]
        public IActionResult EditComment(int movieId, DateTime timeOfWriting, int userId, string description)
        {
            var movie = _webDbContext.Movies.First(movie => movie.Id == movieId);
           /* movie.Comments.First(comment =>
                comment.TimeOfWriting == timeOfWriting && comment.User.Id == userId).Description = description;
*/
            return RedirectToAction("Movie", RedirectMovieById(movie.Id));
        }

        public IActionResult RemoveCommentOnMovie(int movieId, DateTime timeOfWriting, int userId)
        {
            var movie = _webDbContext.Movies.First(movie => movie.Id == movieId);

            /*var comment = movie.Comments.FirstOrDefault((comment) =>
                comment.TimeOfWriting == timeOfWriting && comment.User.Id == userId);
            if (comment != null)
            {
                movie.Comments.Remove(comment);
                var user = Users.First(u => u.Id == userId);
                var userComment = user.Comments.First(c => c.TimeOfWritng == timeOfWriting);
                user.Comments.Remove(userComment);
            }
*/
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
