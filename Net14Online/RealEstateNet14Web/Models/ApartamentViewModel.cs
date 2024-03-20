using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.Models;

public class ApartamentViewModel : BaseModel
{
    public string? City { get; set; }
    
    public string? Street { get; set; }
   
    public int? NumberApartament { get; set; }
   
    public int? Size { get; set; }
    
   public string OwnerName { get; set; }
}