namespace Net14Web.Models.LifeScore
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<PlayerViewModel> Players { get; set; }
        public string Liga {  get; set; }
        public string ShortName { get; set; }
        public List<GameViewModel> CalendarOfGames { get; set; }
        public List<GameViewModel> ResultsOfGames { get; set; }
    }
}
