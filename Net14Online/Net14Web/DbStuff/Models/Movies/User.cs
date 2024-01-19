namespace Net14Web.DbStuff.Models.Movies
{
    public class User : BaseModel
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
