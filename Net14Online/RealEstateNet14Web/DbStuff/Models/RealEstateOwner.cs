using System.Collections.Generic;

namespace RealEstateNet14Web.DbStuff.Models;

public class RealEstateOwner : BaseModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string KindOfActivity { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public virtual List<RealEstate>? RealEstates { get; set; } = new();
    
    public virtual List<Alert> SeenAlerts { get; set; }
    
    public virtual List<Alert> CreatedAlerts { get; set; }
}