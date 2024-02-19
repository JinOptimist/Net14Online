using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services;
using Net14Web.Services.Movies;
using Net14Web.Services.Movies.Permissions;

namespace Net14Web.Controllers.MoviesControllers
{
    public class MoviesController : Controller
    {
        private readonly MovieBuilder _movieBuilder;
        private readonly CommentBuilder _commentBuilder;
        private readonly CreateFilePathHelper _createFilePathHelper;
        private readonly UploadFileHelper _uploadFileHelper;
        private readonly AdminPanelPermissions _adminPanelPermissions;
        private readonly MoviePermissions _moviePermissions;

        private MoviesRepository _movieRepository;
        private CommentRepository _commentRepository;
        private AuthService _authService;

        private string _straightPathForMovies = "";

        private const int COUNT_MOVIES_ON_INDEX = 10;
        private const string DEFAULT_MOVIE_POSTER_PATH_FOR_DB = "/images/movies/moviePosters/";
        private const string DEFAULT_MOVIE_POSTER_NAME = "moviePoster_";

        public MoviesController(MovieBuilder movieBuilder, CommentBuilder commentBuilder, MoviesRepository moviesRepository, 
            CommentRepository commentRepository, CreateFilePathHelper createFilePathHelper, UploadFileHelper uploadFileHelper, 
            AuthService authService, AdminPanelPermissions adminPanelPermissions, MoviePermissions moviePermissions)
        {
            _movieBuilder = movieBuilder;
            _commentBuilder = commentBuilder;
            _movieRepository = moviesRepository;
            _commentRepository = commentRepository;
            _createFilePathHelper = createFilePathHelper;
            _uploadFileHelper = uploadFileHelper;
            _commentRepository = commentRepository;
            _straightPathForMovies = _createFilePathHelper.GetStraightPath("images", "movies", "moviePosters");
            _authService = authService;
            _adminPanelPermissions = adminPanelPermissions;
            _moviePermissions = moviePermissions;
        }

        [Route("movies/index")]
        public IActionResult Index()
        {
            var movies = _movieRepository
                .GetMovies(COUNT_MOVIES_ON_INDEX)
                .Select(m => _movieBuilder.RebuildMovieToMovieViewModel(m))
                .ToList();
            var indexViewModel = new MovieIndexViewModel
            {
                MovieViewModels = movies,
                CanAccessToAdminPanel = false
            };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = _authService.GetCurrentUserId().Value;
                indexViewModel.UserId = userId;
                indexViewModel.CanAccessToAdminPanel = _adminPanelPermissions.CanAccessToAdminPanel();
            }
            return View(indexViewModel);
        }

        [HttpGet]
        [Route("movies/movie/{movieId?}")]
        public async Task<IActionResult> Movie(int movieId)
        {
            var movie = await _movieRepository.GetMovieWithCommentsAsync(movieId);
            if (movie != null)
            {
                var movieView = _movieBuilder.RebuildMovieToMovieViewModelWithComments(movie);
                movieView.CanAddCommentToMovie = _moviePermissions.CanAddCommentToMovie();
                return View(movieView);
            }
            return Content("The movie was not found");
        }

        public IActionResult AddMovie()
        {
            var newMove = new AddMovieViewModel
            {
                CanAddMovie = _moviePermissions.CanAddMovie()
            };
            return View(newMove);
        }

        [HttpPost]
        [Authorize]
        [Permission(PermissionType.AddMovie)]
        public async Task<IActionResult> AddMovie(AddMovieViewModel addMovie)
        {
            if (addMovie.Poster is null)
            {
                return Content("You don't add poster.");
            }
            var extension = Path.GetExtension(addMovie.Poster.FileName);
            var movie = _movieBuilder.BuildMovie(addMovie, "");
            var fileName = $"{DEFAULT_MOVIE_POSTER_NAME}{movie.Id}{extension}";
            if (await SaveMoviePoster(addMovie.Poster, fileName))
            {
                var urlPath = $"{DEFAULT_MOVIE_POSTER_PATH_FOR_DB}{fileName}";
                movie.PosterUrl = urlPath;
                await _movieRepository.AddAsync(movie);
                return RedirectToAction("movie", new { movieId = movie!.Id });
            }
            return Content("The movie wasn't added.");
        }

        public async Task<bool> SaveMoviePoster(IFormFile poster, string fileName)
        {
            var path = _createFilePathHelper.GetCombinePath(_straightPathForMovies, fileName);
            return await _uploadFileHelper.UploadFile(path, poster);
        }

        [HttpPost]
        [Authorize]
        [Permission(PermissionType.AddCommentToMovie)]
        public async Task<IActionResult> AddCommentOnMovie(int movieId, string description)
        {
            if (description == "")
            {
                return Content("Comment is empty.");
            }
            var timeOfWriting = DateTime.Now;
            var movie = await _movieRepository.GetByIdAsync(movieId)!;
            var user = _authService.GetCurrentUser();
            var comment = _commentBuilder.BuildComment(timeOfWriting, description, user, movie!);
            await _commentRepository.AddAsync(comment);
            return RedirectToAction("movie", new { movieId = movie!.Id});
        }

        [Authorize]
        [Permission(PermissionType.DeleteCommentOnMovie)]
        public async Task<IActionResult> DeleteCommentOnMovie(int commentId)
        {
            var comment = await _commentRepository.GetByIdCommentWithMovieAsync(commentId)!;
            var movieId = comment!.Movie.Id;
            await _commentRepository.DeleteAsync(commentId);
            return RedirectToAction("movie", new { movieId = movieId });
        }
    }
}
