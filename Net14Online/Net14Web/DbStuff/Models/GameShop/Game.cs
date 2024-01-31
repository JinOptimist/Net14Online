namespace Net14Web.DbStuff.Models.GameShop
{
    public class Game : BaseModel
    {
        public string Name { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public double? Raiting { get; set; }

        public string? Genre { get; set; }

        public virtual List<GameComment>? Comments { get; set; }
    }
}
