using Microsoft.EntityFrameworkCore;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.Models.Alerts;

namespace RealEstateNet14Web.DbStuff.Repositories;

public class AlertRepository : RealEstateBaseRepository<Alert>
{
    public AlertRepository(WebRealEstateDbContext webRealEstateDbContext) : base(webRealEstateDbContext){}

    public void MarkAsReaded(int alertId, RealEstateOwner user)
    {
        var alert = _entyties
           .Include(x => x.NotificatedRealEstateOwners)
           .Single(x => x.Id == alertId);
       
       alert.NotificatedRealEstateOwners.Add(user);
       _webRealEstateDbContext.SaveChanges();
    }

    public List<AlertInfoViewModel> GetUnseedAlerts(int userId)
    {
       return _entyties
           .Where(alert => !alert.NotificatedRealEstateOwners
                .Any(realEstateOwner => realEstateOwner.Id == userId))
            .Select(x => new AlertInfoViewModel
            {
                Message = x.Message,
                AlertId = x.Id

            }).ToList();
    }
}