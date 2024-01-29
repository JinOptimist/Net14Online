using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.RealEstate.Models;

public class Apartament : BaseModel
{
    public string Size { get; set; }
    
    public virtual ApartmentOwner? ApartmentOwner { get; set; }
    
}