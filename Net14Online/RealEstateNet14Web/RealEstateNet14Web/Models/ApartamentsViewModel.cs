using Microsoft.AspNetCore.Mvc.Rendering;

namespace RealEstateNet14Web.Models;

public class ApartamentsViewModel
{
    public List<SelectListItem> ApartamentOwners { get; set; }
    
    public List<SelectListItem> Apartaments { get; set; }
}