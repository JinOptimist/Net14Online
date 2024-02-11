using System.Collections.Generic;
using Net14Web.DbStuff.RealEstate.Models;

namespace Net14Web.Models.RealEstate;

public class ApartmentOwnerViewModel
{
   public string Name { get; set; }
   public int Age { get; set; }
   public string KindOfActivity { get; set; }
   
   public string? Login { get; set; }
   
   public string? Password { get; set; }

   public string? Email { get; set; }
   
   public virtual List<Apartament>? Apartaments { get; set; } = new();

  
}