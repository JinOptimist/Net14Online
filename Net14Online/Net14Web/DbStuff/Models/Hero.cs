using Net14Web.DbStuff.Models.Enums;

namespace Net14Web.DbStuff.Models
{
    public class Hero : BaseModel
    {
        public string Name { get; set; }
        public int Coins { get; set; }
        public int Hp {  get; set; }
        public DateTime Birthday { get; set; }

        public Race Race { get; set; } = Race.Human;

        public virtual Weapon? FavoriteWeapon { get; set; }
        public virtual List<Weapon> KnowedWeapons { get; set; }
    }
}
