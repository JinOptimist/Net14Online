using RealEstateNet14Web.DbStuff.Models;

namespace RealEstateNet14Web.DbStuff.Repositories;

public class AlertRepository : RealEstateBaseRepository<Alert>
{
    public AlertRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext){}
}