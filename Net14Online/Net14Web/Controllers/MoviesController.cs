using Microsoft.AspNetCore.Mvc;
using Net14Web.Models.Dnd;
using Net14Web.Models.Movies;

namespace Net14Web.Controllers
{
    public class MoviesController : Controller
    {
        public static List<PersoneViewModel> Persones = new List<PersoneViewModel>();

        private static int _personId = -1;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonalAccount()
        {
            if (_personId != -1)
            {
                return View(Persones[_personId]);
            }
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

        [HttpGet]
        public IActionResult Movie()
        {
            List<CommentsOnMovieViewModel> commentsOnMovieViews = new List<CommentsOnMovieViewModel>();
            if (_personId != -1)
            {
                commentsOnMovieViews.Add(new CommentsOnMovieViewModel() { Description = "Класс!", TimeOfWritng = DateTime.Now, Persone = Persones[0] });
                commentsOnMovieViews.Add(new CommentsOnMovieViewModel() { Description = "ВАУ!", TimeOfWritng = DateTime.Now, Persone = Persones[0] });
            };

            MovieViewModel movieViewModel = new MovieViewModel
            {
                PosterUrl = "https://goo.su/KugxHc",
                Title = "Рождество кота Боба",
                Description = "До встречи с котом Бобом Джеймс не любил Рождество, но рыжий пушистый хулиган всё изменил. Он в буквальном смысле подарил своему хозяину новую жизнь, сотворив настоящее рождественское чудо. Ведь даже если у тебя пусто в кармане, а во всём городе отключили свет, праздник должен состояться!",
                Comments = commentsOnMovieViews
            };

            return View(movieViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginPersoneViewModel loginPersone)
        {
            for (int i = 0; i < Persones.Count; i++)
            {
                if (Persones[i].Login == loginPersone.Login && Persones[i].Password == loginPersone.Password)
                {
                    _personId = i;
                    return RedirectToAction("PersonalAccount");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Registration(CreatePersoneViewModel createPersone)
        {
            MovieViewModel movieViewModel = new MovieViewModel
            {
                PosterUrl = "https://goo.su/KugxHc",
                Title = "Рождество кота Боба"
            };

            List<CommentsInPersoneAccount> commentsOnMovieViews = new List<CommentsInPersoneAccount>()
            {
                new CommentsInPersoneAccount() { Description = "Класс!", TimeOfWritng = DateTime.Now, Movie = movieViewModel },
                new CommentsInPersoneAccount() { Description = "Вау!", TimeOfWritng = DateTime.Now, Movie = movieViewModel }
            };

            PersoneViewModel persone = new PersoneViewModel
            {
                Login = createPersone.Login,
                Email = createPersone.Email,
                Password = createPersone.Password,
                AvatarUrl = "https://goo.su/w7Qh", 
                Comments = commentsOnMovieViews
            };

            Persones.Add(persone);
            return RedirectToAction("Login");
        }
    }
}
