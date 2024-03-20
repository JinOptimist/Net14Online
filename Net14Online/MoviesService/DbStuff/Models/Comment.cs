namespace CommentMoviesMicroService.DbStuff.Model
{
    public class Comment : BaseModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserAvatarUrl { get; set; }
        public string? Description { get; set; }
        public DateTime? TimeOfWriting { get; set; }
    }
}
