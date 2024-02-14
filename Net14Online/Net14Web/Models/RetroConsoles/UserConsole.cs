using Net14Web.Models.RetroConsoles;
using System.Collections.Generic;

namespace Net14Web.Models.RetroConsoles
{
    public class UserConsole
    {
        public int Id { get; set; }
        public string PicUrl { get; set; }
        public string Name { get; set; }
        public int NumOfConsoles { get; set; }
        public string Discription { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ConsoleInfo> Consoles { get; set; } = new List<ConsoleInfo>();
    }

    public class ConsoleInfo
    {
        public string ConsoleName { get; set; }
        public int Year { get; set; }
    }
}
