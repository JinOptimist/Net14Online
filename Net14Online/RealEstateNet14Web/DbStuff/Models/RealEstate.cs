namespace RealEstateNet14Web.DbStuff.Models;

public class RealEstate : BaseModel
{
    public string City { get; set; }
    public string Street { get; set; }
    public int? Size { get; set; }
    
    public string TypeRealEstate { get; set; }
    public string Status { get; set; }
    
    public int Price { get; set; }
    public virtual RealEstateOwner? RealEstateOwner { get; set; }

}