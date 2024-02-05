using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net14Web.Models.RealEstate;

public class ApartamentsViewModel
{
    public List<SelectListItem> ApartamentOwners { get; set; }
    
    public List<SelectListItem> Apartaments { get; set; }
}