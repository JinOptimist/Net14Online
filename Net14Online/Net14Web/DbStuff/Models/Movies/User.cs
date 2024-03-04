namespace Net14Web.DbStuff.Models.Movies
{
    public class User : BaseModel
    {
        public string? Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Password { get; set; }
        public string? AvatarUrl { get; set; }
        public virtual List<Comment>? Comments { get; set; }
        public virtual List<Hero> MyHeroes { get; set; }
    }
}
