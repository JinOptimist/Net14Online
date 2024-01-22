using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net14Web.Models.Dnd
{
    public class FavoriteWeaponViewModel
    {
        public List<SelectListItem> Heroes { get; set; }
        public List<SelectListItem> Weapons { get; set; }
    }
}
