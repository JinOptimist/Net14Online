namespace Net14Web.Services.ApiServices.Dtos.LifeScore
{
    public class LeagueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type{ get; set; }
        public string LogoUrl{ get; set; }
        public CountryDto Country{ get; set; }
        public List<SeasonDto> Seasons { get; set; }
    }
}
