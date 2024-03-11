namespace Net14Web.Models.Movies
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CommentOnMovieViewModel> Comments { get; set; }

        public bool CanAddCommentToMovie { get; set; }
    }
}
