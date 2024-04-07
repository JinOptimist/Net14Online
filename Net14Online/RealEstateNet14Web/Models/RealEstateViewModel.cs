using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.Models;

public class RealEstateViewModel : BaseModel
{
    public string City { get; set; }
    public string Street { get; set; }
    public int? Size { get; set; }
    
    public string TypeRealEstate { get; set; }
    public string Status { get; set; }
    
    public int Price { get; set; }
    
   public string OwnerName { get; set; }
}