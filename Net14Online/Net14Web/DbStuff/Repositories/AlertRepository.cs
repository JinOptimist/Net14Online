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
                .Where(alert => !alert
                    .NotifiedUsers
                    .Any(notifiedUsers => notifiedUsers.Id == userId))
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
    }
}
