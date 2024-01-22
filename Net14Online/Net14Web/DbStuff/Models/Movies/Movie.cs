namespace Net14Web.DbStuff.Models.Movies
{
    public class Movie : BaseModel
    {
        public string? PosterUrl { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
