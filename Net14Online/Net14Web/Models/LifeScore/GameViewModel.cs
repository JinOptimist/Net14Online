namespace Net14Web.Models.LifeScore
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }
        public int FirstTeamGoals { get; set; }
        public int SecondTeamGoals { get; set; }
        public DateTime GameDate { get; set; }
        public string Result { get; set; }
    }
}
