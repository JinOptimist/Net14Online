namespace Net14Web.Services
{
    public class RandomHelper
    {
        private static Random _random = new Random(); 
        private List<string> AvailableNames = new List<string> { "Olga", "Lera", "Smith" };
        
        public string GetRandomName()
        {
            var index = _random.Next(AvailableNames.Count);
            return AvailableNames[index];
        }
    }
}
