using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Movies;
using Net14Web.Services.Movies;

namespace Net14Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieBuilder _movieBuilder;
        private readonly ErrorBuilder _errorBuilder;
        private readonly UserBuilder _userBuilder;
        private readonly LoginHelper _loginHelper;
        private readonly RedirectBuilder _redirectBuilder;
        private readonly CommentBuilder _commentBuilder;

        public static List<UserViewModel> Users = new List<UserViewModel>();
        public static List<MovieViewModel> Movies = new List<MovieViewModel>();
        public static AdminPanelViewModel AdminPanelViewModel = new AdminPanelViewModel();

        private static int activeUserId = -1;

        public MoviesController(MovieBuilder movieBuilder, ErrorBuilder errorBuilder,
            UserBuilder userBuilder, RedirectBuilder redirectBuilder, 
            CommentBuilder commentBuilder, LoginHelper loginHelper)
        {
            AdminPanelViewModel.Users = Users;
            AdminPanelViewModel.Movies = Movies;

            _movieBuilder = movieBuilder;
            _errorBuilder = errorBuilder;
            _userBuilder = userBuilder;
            _redirectBuilder = redirectBuilder;
            _loginHelper = loginHelper;
            _commentBuilder = commentBuilder;
        }

        public IActionResult Index()
        {
            return View(Movies);
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
            var movie = _movieBuilder.BuildMovie(Movies.Count, addMovie);
            Movies.Add(movie);
            return RedirectToAction("Movie", _redirectBuilder.BuildRedirectMovieById(movie.Id));
        }

        [HttpPost]
        public IActionResult Registration(AddUserViewModel addUser)
        {
            var user = _userBuilder.BuildUser(Users.Count, addUser);
            Users.Add(user);
            activeUserId = user.Id;
            return RedirectToAction("User", _redirectBuilder.BuildRedirectUserById(activeUserId));
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel loginUser)
        {
            var user = _loginHelper.FindLoggedUser(Users, loginUser);
            if (user != null)
            {
                activeUserId = user.Id;
                return RedirectToAction("User", _redirectBuilder.BuildRedirectUserById(activeUserId));
            }
            return View();
        }

        [HttpGet]
        public new IActionResult User(int userId)
        {
            var user = Users[userId];
            return View(user);
        }

        [HttpGet]
        public IActionResult Movie(int movieId)
        {
            var movie = Movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movie != null)
            {
                return View(movie);
            }
            return RedirectToAction("Error", _errorBuilder.BuildError("Movie", "The movie was not found"));
        }

        [HttpPost]
        public IActionResult AddCommentOnMovie(int movieId, string description)
        {
            if (activeUserId == -1)
            {
                return RedirectToAction("Movie", _redirectBuilder.BuildRedirectMovieById(movieId));
            }

            var movie = Movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movie != null)
            {
                var timeOfWriting = DateTime.Now;
                var user = Users[activeUserId];
                var movieComment = _commentBuilder.BuildCommentToMovie(timeOfWriting, description, user);
                var userComment = _commentBuilder.BuildCommentToUser(timeOfWriting, description, movie);
                movie.Comments.Add(movieComment);
                user.Comments.Add(userComment);
            }
            return RedirectToAction("Movie", _redirectBuilder.BuildRedirectMovieById(movieId));
        }

        [HttpPost]
        public IActionResult EditComment(int movieId, string timeOfWriting, int userId, string description)
        {
            var movie = Movies.First(movie => movie.Id == movieId);
            movie.Comments.First(comment =>
                comment.TimeOfWriting.ToString() == timeOfWriting && comment.User.Id == userId).Description = description;

            return RedirectToAction("Movie", _redirectBuilder.BuildRedirectMovieById(movie.Id));
        }

        public IActionResult RemoveCommentOnMovie(int movieId, string timeOfWriting, int userId)
        {
            var movie = Movies.First(movie => movie.Id == movieId);

            var comment = movie.Comments.FirstOrDefault((comment) =>
                comment.TimeOfWriting.ToString() == timeOfWriting && comment.User.Id == userId);
            if (comment != null)
            {
                movie.Comments.Remove(comment);
                var user = Users.First(u => u.Id == userId);
                var userComment = user.Comments.First(c => c.TimeOfWritng.ToString() == timeOfWriting);
                user.Comments.Remove(userComment);
            }

            return RedirectToAction("Movie", _redirectBuilder.BuildRedirectMovieById(movieId));
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public IActionResult EditUser(UserViewModel editUser)
        {
            var user = Users.First(user => user.Id == editUser.Id);
            Users.Remove(user);
            editUser.Comments = user.Comments;
            Users.Add(editUser);
            Users = Users.OrderBy(u => u.Id).ToList();
            return RedirectToAction("AdminPanel");
        }

        /// <summary>
        /// AdminPanel
        /// </summary>
        [HttpPost]
        public IActionResult EditMovie(MovieViewModel editMovie)
        {
            var movie = Movies.First(m => m.Id == editMovie.Id);
            Movies.Remove(movie);
            Movies.Add(editMovie);
            Movies = Movies.OrderBy(m => m.Id).ToList();
            return RedirectToAction("AdminPanel");
        }
    }
}
