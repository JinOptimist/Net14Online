namespace Net14Web.Models.LifeScore
{
    public class CreateTeamViewModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public List<PlayerViewModel> Players { get; set; }
        public string Liga { get; set; }
        public string ShortName { get; set; }
    }
}
