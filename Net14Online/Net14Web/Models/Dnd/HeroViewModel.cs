using Net14Web.DbStuff.Models.Enums;

namespace Net14Web.Models.Dnd
{
    public class HeroViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string FavWeaponName { get; set; }
        public int Coins { get; set; }
        public int Age { get; set; }
        public Race Race { get; set; }
        public string OwnerName { get; set; }
        public bool CanDelete { get; set; }
        public List<string> Tools { get; set; }
    }
}
