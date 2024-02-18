namespace RealEstateNet14Web.DbStuff.Models;

public class Apartament : BaseModel
{
    public string Size { get; set; }
    
    public string? Address { get; set; }
    
    public virtual ApartmentOwner? ApartmentOwner { get; set; }

}