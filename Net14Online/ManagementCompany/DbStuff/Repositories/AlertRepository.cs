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

        public void MarkAsRead(User user, int alertId)
        {
            //var nonValidAlerts = _entities
            //    .Include(x => x.Author)
            //    .Include(u => u.NotifiedUsers)
            //    .Where(alert => !alert
            //    .NotifiedUsers
            //    .Any(notifiedUser => notifiedUser.Id == user.Id))
            //    .Where(x => x.ExpireDate < DateTime.Now)
            //    .ToList();

            //foreach (var nonValidAlert in nonValidAlerts)
            //{
            //    nonValidAlert.NotifiedUsers.Add(user);
            //    _context.SaveChanges();
            //}

            var alert = GetById(alertId);
            alert.NotifiedUsers.Add(user);

            _context.SaveChanges();
        }

        public List<AlertViewModel> GetUnreadAndActualAlerts(int userId)
        {
            var alerts = _entities
                .Include(x => x.Author)
                .Where(x => x.IsActive)
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

            return alerts;
        }

        public IEnumerable<Alert> GetLastAlerts()
        {
            return _entities
                .OrderByDescending(x => x.CreationDate)
                .Take(3);
        }

        public int MarkAsReadAllExpiredAlerts()
        {
            var markOnReadAlerts = _entities
                .Where(x => x.IsActive)
                .Where(x => x.ExpireDate < DateTime.Now)
                .ToList();

            foreach (var alert in markOnReadAlerts)
            {
                alert.IsActive = false;
            }
            _context.SaveChanges();

            return markOnReadAlerts.Count();
        }
    }
}
