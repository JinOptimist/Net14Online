namespace Net14Web.Models.Movies
{
    public class AddMovieViewModel
    {
        public IFormFile Poster { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool CanAddMovie { get; set; }
    }
}
