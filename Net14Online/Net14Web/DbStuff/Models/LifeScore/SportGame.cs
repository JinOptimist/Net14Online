namespace Net14Web.DbStuff.Models.LifeScore
{
    public class SportGame : BaseModel
    {
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int? Team1Goals { get; set; }
        public int? Team2Goals { get; set; }
        public DateTime Date { get; set; }
        public string? TeamWin { get; set; }
    }
}
