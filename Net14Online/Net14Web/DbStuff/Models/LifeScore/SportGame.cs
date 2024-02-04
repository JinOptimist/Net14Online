namespace Net14Web.DbStuff.Models.LifeScore
{
    public class SportGame : BaseModel
    {
        
        public int? Team1Goals { get; set; }
        public int? Team2Goals { get; set; }
        public DateTime Date { get; set; }
        public int? TeamIDWin { get; set; }

        public ICollection<Team> Teams { get; set; } = default!;
    }
}
