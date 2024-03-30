using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;
using System.Security.Claims;
using ManagementCompany.Models.Alerts;

namespace ManagementCompany.DbStuff.Repositories
{
    public class AlertRepository : BaseRepository<Alert>
    {
        public AlertRepository(ManagementCompanyDbContext context) : base(context) { }

        public override Alert GetById(int id)
        {
            return _entities.Include(u => u.Author)
                .Include(u => u.NotifiedUsers)
                .SingleOrDefault(ent => ent.Id == id);
        }

        public override IEnumerable<Alert> GetAll()
        {
            return _entities
                .Include(u => u.Author)
                .OrderBy(cd => cd.CreationDate);
        }

        public IEnumerable<Alert> GetArticles()
        {
            return _entities
                .Include(x => x.Author);
        }

        public void MarkAsRead(User user, int alertId)
        {
            var alert = GetById(alertId);
            alert.NotifiedUsers.Add(user);
            alert.IsRead = true;
            _context.SaveChanges();
        }

        public IEnumerable<object> GetUnreadAlerts()
        {
            throw new NotImplementedException();
        }

        public List<AlertViewModel> GetUnreadAndActualAlerts(int userId)
        {
            var alerts = _entities
                .Include(x => x.Author)
                .Where(alert => !alert
                .NotifiedUsers
                .Any(notifiedUser => notifiedUser.Id == userId))
                .Where(x => x.ExpireDate > DateTime.Now)
                .Select(x => new AlertViewModel
                {
                    AlertId = x.Id,
                    Message = x.Message,
                })
                .ToList();

            //var nonValidAlerts = _entities
            //    .Include(x => x.Author)
            //    .Where(alert => !alert
            //    .NotifiedUsers
            //    .Any(notifiedUser => notifiedUser.Id == userId))
            //    .Where(x => x.ExpireDate < DateTime.Now)
            //    .Select(x => new AlertViewModel
            //    {
            //        AlertId = x.Id,
            //        Message = x.Message,
            //    })
            //    .ToList();

            //return alerts.Concat(nonValidAlerts).ToList*();
            return alerts;
        }

        public IEnumerable<Alert> GetLastAlerts()
        {
            return _entities
                .OrderByDescending(x => x.CreationDate)
                .Take(3);
        }
    }
}
