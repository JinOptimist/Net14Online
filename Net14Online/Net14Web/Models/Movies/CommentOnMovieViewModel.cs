namespace Net14Web.Models.Movies
{
    public class CommentOnMovieViewModel
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime TimeOfWriting { get; set; }
        public CommentUserOnMovie User { get; set; }

        public bool CanRemoveCommentFromMovie { get; set; }
    }

    public class CommentUserOnMovie
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string AvatarUrl { get; set; }
    }
}
