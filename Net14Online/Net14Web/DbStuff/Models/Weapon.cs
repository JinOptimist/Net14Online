namespace Net14Web.DbStuff.Models
{
    public class Weapon : BaseModel
    {
        public string Name { get; set; }
        public int Damage { get; set; }

        public virtual List<Hero> HeroesWhoLikeTheWeapon { get; set; }

        public virtual List<Hero> HeroesWhoKnowsTheWeapon { get; set; }
    }
}
