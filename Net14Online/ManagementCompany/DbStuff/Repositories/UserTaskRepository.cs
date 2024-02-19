using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.ManagmentCompany.Models;
using ManagementCompany.DbStuff.ManagmentCompany.Models.Enums;
using ManagementCompany.Models.ManagmentCompany;

namespace ManagementCompany.DbStuff.Repositories
{
    public class UserTaskRepository : ManagmentCompanyBaseRepository<UserTask>
    {
        public UserTaskRepository(ManagmentCompanyDbContext context) : base(context) { }

        public IEnumerable<UserTask> GetInPgogressTasks()
        {
            return _entities
                .Include(x => x.Status)
                .Where(x => x.Status.Id != (int)UserTaskStatusEnum.Complete);
        }

        public IEnumerable<UserTask> GetCompletedTasks()
        {
            return _entities
                .Include(x => x.Status)
                .Where(x => x.Status.Id == (int)UserTaskStatusEnum.Complete);
        }

        public IEnumerable<UserTask> GetCurrentUserTasks(User user)
        {
            return _entities
                .Include(t => t.Author)
                .Include(t => t.Status)
                .Where(t => t.Author.Id == user.Id)
                .ToList();
        }
    }
}
