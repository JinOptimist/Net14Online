namespace Net14Web.DbStuff.Models.Movies
{
    public class Comment : BaseModel
    {
        public string? Description { get; set; }
        public DateTime TimeOfWriting { get; set; }
    }
}
