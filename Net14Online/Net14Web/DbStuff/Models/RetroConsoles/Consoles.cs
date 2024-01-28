using Net14Web.Models.RetroConsoles;

namespace Net14Web.DbStuff.Models.RetroConsoles
{
    public class Consoles:BaseModel
    {
        public string ConsoleName { get; set; }
        public int Year { get; set; }
        public virtual List<ConsolesRetroUser> ConsolesRetroUsers { get; set; } = new List<ConsolesRetroUser>();
    }
}
