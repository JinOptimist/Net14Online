using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RealEstateNet14Web.Models;

public class RealEstatesViewModel
{
    public List<SelectListItem> RealEstateOwners { get; set; }
    
    public List<SelectListItem> RealEstate { get; set; }
}