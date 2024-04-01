using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.Models.Alerts;

namespace Net14Web.DbStuff.Repositories
{
    public class AlertRepository : BaseRepository<Alert>
    {
        public AlertRepository(WebDbContext context) : base(context) { }

        public List<AlertShortInfoViewModel> GetUnseedAlerts(int userId)
        {
            return _entyties
                .Where(x => x.IsActive)
                .Where(alert => !alert
                    .NotifiedUsers
                    .Any(notifiedUsers => notifiedUsers.Id == userId)
                    )
                .Select(x => new AlertShortInfoViewModel
                {
                    AlertId = x.Id,
                    Message = x.Message,
                })
                .ToList();
        }

        public void MarkAsReaded(int alertId, User user)
        {
            var alert = _entyties
                .Include(x => x.NotifiedUsers)
                .Single(x => x.Id == alertId);

            alert.NotifiedUsers.Add(user);
            _context.SaveChanges();
        }

        public int MarkAsReadedAllExpiredAlerts()
        {
            var expiredAlerts = _entyties
                .Where(x => x.ExpiredDate < DateTime.Now)
                .ToList();

            foreach (var alert in expiredAlerts)
            {
                alert.IsActive = false;
            }

            _context.SaveChanges();

            return expiredAlerts.Count();
        }
    }
}
