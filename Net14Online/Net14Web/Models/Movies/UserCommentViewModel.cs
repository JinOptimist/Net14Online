namespace Net14Web.Models.Movies
{
    public class UserCommentViewModel
    {
        public string Description { get; set; }
        public DateTime TimeOfWritng { get; set; }
        public MovieUserComment Movie { get; set; }
    }

    public class MovieUserComment
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
    }
}
