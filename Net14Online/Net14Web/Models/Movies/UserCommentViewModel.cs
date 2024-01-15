namespace Net14Web.Models.Movies
{
    public class UserCommentViewModel
    {
        public string Description { get; set; }
        public DateTime TimeOfWritng { get; set; }
        public MovieViewModel Movie { get; set; }
    }
}
