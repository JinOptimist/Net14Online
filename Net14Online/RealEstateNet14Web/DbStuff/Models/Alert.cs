using System.Collections.Generic;

namespace RealEstateNet14Web.DbStuff.Models;

public class Alert : BaseModel
{
    public string Message { get; set; }
    
    public virtual RealEstateOwner Creator { get; set; }
    
    public virtual List<RealEstateOwner> NotificatedRealEstateOwners { get; set; }
}