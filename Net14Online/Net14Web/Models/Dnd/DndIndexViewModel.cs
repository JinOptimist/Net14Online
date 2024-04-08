namespace Net14Web.Models.Dnd
{
    public class DndIndexViewModel
    {
        public string UserName { get; set; }
        public bool CanChooseFavoriteWeapon { get; set; }
        public PaginatorViewModel<HeroViewModel> PaginatorViewModel { get; set; }
        public List<WeaponViewModel> Weapons { get; set; }
    }
}
