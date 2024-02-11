using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.RealEstate.Models;

public class Apartament : BaseModel
{
    public string City { get; set; }
    public string Street { get; set; }
    public int NumberApartament { get; set; }
    public int Size { get; set; }
    public virtual ApartmentOwner? ApartmentOwner { get; set; }
    
}