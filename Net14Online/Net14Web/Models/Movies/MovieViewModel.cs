namespace Net14Web.Models.Movies
{
    public class MovieViewModel
    {
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CommentsOnMovieViewModel> Comments { get; set; }
    }
}
