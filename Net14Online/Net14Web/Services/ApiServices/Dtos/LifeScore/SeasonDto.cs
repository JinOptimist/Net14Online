namespace Net14Web.Services.ApiServices.Dtos.LifeScore
{
    public class SeasonDto
    {
        public int Season { get; set; }
        public bool Current { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
