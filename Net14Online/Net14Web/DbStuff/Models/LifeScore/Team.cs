namespace Net14Web.DbStuff.Models.LifeScore
{
    public class Team : BaseModel
    {
        public string Name { get; set; }
        public string Liga { get; set; }
        public string ShortName { get; set; }
        public string Country { get; set; }

        public ICollection<SportGame> Games { get; set; } = default!;
        public ICollection<Player> Players { get; set; } = default!;
    }
}
