using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.Models.GameShop
{
    public class GameViewModel : BaseModel
    {
        public string? Name { get; set; }

        public string? PosterUrl { get; set; }

        public double? Rating { get; set; }

        public string? Genre { get; set; }

        public List<string>? Comments { get; set; }
    }
}
