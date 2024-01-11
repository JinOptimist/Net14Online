namespace Net14Web.Models.Movies
{
    public class CommentsOnMovieViewModel
    {
        public string Description { get; set; }
        public DateTime TimeOfWriting { get; set; }
        public UserViewModel User { get; set; }
    }
}
