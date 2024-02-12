using Net14Web.DbStuff.Models.GameShop;

namespace Net14Web.Models.GameShop
{
    public record GameDto
    {
        public int Id { get; init; }

        public string Name { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public double? Raiting { get; set; }

        public string? Genre { get; set; }

        public List<GameComment>? Comments { get; set; }
    }
}
