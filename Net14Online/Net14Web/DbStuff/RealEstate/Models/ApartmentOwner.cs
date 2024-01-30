using Net14Web.DbStuff.Models;

namespace Net14Web.DbStuff.RealEstate.Models;

public class ApartmentOwner : BaseModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string KindOfActivity { get; set; }
    
}