using Net14Web.DbStuff.RealEstate.Models;

namespace Net14Web.Models.RealEstate;

public class ApartamentViewModel
{
    public string City { get; set; }
   
    public string Street { get; set; }
    
    public int NumberApartament { get; set; }
    
    public int Size { get; set; }
    
    public string OwnerName { get; set; }
    
    public virtual ApartmentOwner? ApartmentOwner { get; set; }
}