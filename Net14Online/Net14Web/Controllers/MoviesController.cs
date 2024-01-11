using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Movies;

namespace Net14Web.Controllers
{
    public class MoviesController : Controller
    {
        public static List<UserViewModel> Users = new List<UserViewModel>();
        public static List<MovieViewModel> Movies = new List<MovieViewModel>();
        public static AdminPanelViewModel AdminPanelViewModel = new AdminPanelViewModel();

        public MoviesController()
        {
            AdminPanelViewModel.Users = Users;
            AdminPanelViewModel.Movies = Movies;
        }

        private static int activeUserId = -1;

        public IActionResult Index()
        {
            return View();
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
        public IActionResult AddMovie(AddMovieViewModel movie)
        {
            var id = Movies.Count;
            var newMovie = new MovieViewModel
            {
                Id = id,
                Title = movie.Title,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl,
                Comments = new ()
            };
            Movies.Add(newMovie);
            return RedirectToAction("Movie", new { movieId = newMovie.Id });
        }

        [HttpPost]
        public IActionResult Registration(AddUserViewModel addUser)
        {
            var id = Users.Count;
            UserViewModel user = new UserViewModel
            {
                Id = id,
                Login = addUser.Login,
                Email = addUser.Email,
                Password = addUser.Password,
                AvatarUrl = "https://goo.su/w7Qh",
                Comments = new ()
            };
            Users.Add(user);
            activeUserId = user.Id;
            return RedirectToAction("User", new { userId = id });
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel loginUser)
        {
            foreach (var user in Users)
            {
                if (user.Login.ToLower() == loginUser.Login.ToLower() && user.Password == loginUser.Password)
                {
                    activeUserId = user.Id;
                    return RedirectToAction("User", new { userId = activeUserId });
                }
            }
            return View();
        }

        [HttpGet]
        public new IActionResult User(int userId)
        {
            return View(Users[userId]);
        }

        [HttpGet]
        public IActionResult Movie(int movieId)
        {
            var movie = Movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movie != null)
            {
                return View(movie);
            }
            return RedirectToAction("Error", new ErrorViewModel { Title = "Movie", Description = "The movie was not found" });
        }

        [HttpPost]
        public IActionResult AddCommentOnMovie(int movieId, string description)
        {
            var timeOfWriting = DateTime.Now;
            if (activeUserId == -1)
            {
                return RedirectToAction("Movie", new { movieId = movieId });
            }
            var comment = new CommentsOnMovieViewModel
            {
                Description = description,
                TimeOfWriting = timeOfWriting,
                User = Users[activeUserId]
            };

            var movie = Movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movie != null)
            {
                movie.Comments.Add(comment);
                var userComment = new UserCommentViewModel
                {
                    Description = description,
                    TimeOfWritng = timeOfWriting,
                    Movie = movie
                };
                Users[activeUserId].Comments.Add(userComment);
            }

            return RedirectToAction("Movie", new { movieId = movieId });
        }

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

        [HttpPost]
        public IActionResult EditMovie(MovieViewModel editMovie)
        {
            var movie = Movies.First(m => m.Id == editMovie.Id);
            Movies.Remove(movie);
            Movies.Add(editMovie);
            Movies = Movies.OrderBy(m => m.Id).ToList();
            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult EditComment(int movieId, string timeOfWriting, int userId, string description)
        {
            var movie = Movies.FirstOrDefault(movie => movie.Id == movieId);

            if (movie != null)
            {
                var comment = movie.Comments.FirstOrDefault(comment =>
                    comment.TimeOfWriting.ToString() == timeOfWriting && comment.User.Id == userId);
                if (comment != null)
                {
                    comment.Description = description;
                }
            }

            return RedirectToAction("Movie", new { movieId = movie?.Id });
        }

        public IActionResult RemoveCommentOnMovie(int movieId, string timeOfWriting, int userId)
        {
            var movie = Movies.FirstOrDefault(movie => movie.Id == movieId);
            if (movie == null)
            {
                return RedirectToAction("Movie", new { movieId = movieId });
            }

            var comment = movie.Comments.FirstOrDefault((comment) =>
                comment.TimeOfWriting.ToString() == timeOfWriting && comment.User.Id == userId);
            if (comment != null)
            {
                movie.Comments.Remove(comment);
                var user = Users.First(u => u.Id == userId);
                var userComment = user.Comments.First(c => c.TimeOfWritng.ToString() == timeOfWriting);
                user.Comments.Remove(userComment);
            }

            return RedirectToAction("Movie", new { movieId = movieId });
        }
    }
}
