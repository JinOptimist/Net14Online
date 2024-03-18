using Microsoft.AspNetCore.Mvc;
using Net14Web.BusinessServices;
using Net14Web.DbStuff.Repositories.Movies;
using Net14Web.Models.Movies;
using Net14Web.Services;
using Net14Web.Services.Movies;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/api/movies/{action}")]
    public class MovieApiController
    {
        private readonly MovieBuilder _movieBuilder;
        private readonly MoviesRepository _movieRepository;
        private readonly CreateFilePathHelper _createFilePathHelper;
        private readonly UploadFileHelper _uploadFileHelper;
        private readonly MoviesBisinessService _moviesBisinessService;

        private string _straightPathForMovies = "";

        private const string DEFAULT_MOVIE_POSTER_PATH_FOR_DB = "/images/movies/moviePosters/";
        private const string DEFAULT_MOVIE_POSTER_NAME = "moviePoster_";

        public MovieApiController(MovieBuilder movieBuilder, MoviesRepository movieRepository,
            CreateFilePathHelper createFilePathHelper, UploadFileHelper uploadFileHelper, MoviesBisinessService moviesBisinessService)
        {
            _movieBuilder = movieBuilder;
            _movieRepository = movieRepository;
            _createFilePathHelper = createFilePathHelper;
            _uploadFileHelper = uploadFileHelper;
            _straightPathForMovies = _createFilePathHelper.GetStraightPath("images", "movies", "moviePosters");
            _moviesBisinessService = moviesBisinessService;
        }

        public List<MovieViewModel> GetIndexMovies()
        {
            return _moviesBisinessService.GetMoviesForIndexPage();
        } 

        public async Task<bool> AddMovie(AddMovieViewModel addMovie)
        {
            /*if (addMovie.Poster is null)
            {
                return "You don't add poster.";
            }
            var extension = Path.GetExtension(addMovie.Poster.FileName);
            var movie = _movieBuilder.BuildMovie(addMovie, "");
            var fileName = $"{DEFAULT_MOVIE_POSTER_NAME}{movie.Id}{extension}";
            if (await SaveMoviePoster(addMovie.Poster, fileName))
            {
                var urlPath = $"{DEFAULT_MOVIE_POSTER_PATH_FOR_DB}{fileName}";
                movie.PosterUrl = urlPath;
                await _movieRepository.AddAsync(movie);
                return "Done";
            }
            return "The movie wasn't added.";*/
            //var urlPath = $"{DEFAULT_MOVIE_POSTER_PATH_FOR_DB}{fileName}";
            var movie = _movieBuilder.BuildMovie(addMovie, "");
            movie.PosterUrl = "/images/movies/moviePosters/moviePoster_0.png";
            await _movieRepository.AddAsync(movie);
            return true;
        }

        public async Task<bool> SaveMoviePoster(IFormFile poster, string fileName)
        {
            var path = _createFilePathHelper.GetCombinePath(_straightPathForMovies, fileName);
            return await _uploadFileHelper.UploadFile(path, poster);
        }

        [Route("{id}"), HttpDelete("{id}")]
        public async Task DeleteMovie([FromRoute] int id)
        {
            await _movieRepository.DeleteAsync(id);
        }
    }
}
