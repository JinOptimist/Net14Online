namespace Net14Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public string UserName { get; set; }

        public string CurrentLocale { get; set; }

        public int Number {  get; set; }
        public string FactAboutNumber {  get; set; }
        public string MathFactAboutNumber { get; set; }
        public string DogUrl { get; set; }

        public WeatherViewModel WeatherViewModel { get; set; }
    }
}
