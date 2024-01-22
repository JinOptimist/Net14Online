namespace Net14Web.DbStuff.Models.Movies
{
    public class Comment : BaseModel
    {
        public string? Description { get; set; }
        public DateTime TimeOfWriting { get; set; }
        public virtual User User {  get; set; }
        public virtual Movie Movie { get; set; }
    }
}
