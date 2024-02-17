namespace Net14Web.Models.Dnd
{
    public class DndIndexViewModel
    {
        public string UserName { get; set; }
        public bool CanChooseFavoriteWeapon { get; set; }
        public List<HeroViewModel> Heroes { get; set; }
        public List<WeaponViewModel> Weapons { get; set; }
    }
}
