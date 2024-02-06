using Net14Web.DbStuff.Models.Enums;
using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Models
{
    public class Hero : BaseModel
    {
        public string Name { get; set; }
        public int Coins { get; set; }
        public int Hp {  get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }

        public Race Race { get; set; } = Race.Human;

        public virtual User? Owner { get; set; }

        public virtual Weapon? FavoriteWeapon { get; set; }
        public virtual List<Weapon> KnowedWeapons { get; set; }
    }
}
