using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.DbStuff.Repositories
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
