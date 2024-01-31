using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;

namespace Net14Web.DbStuff.Repositories
{
    public class UserTaskRepository : ManagmentCompanyBaseRepository<UserTask>
    {
        public UserTaskRepository(ManagmentCompanyDbContext context) : base(context) { }

        public IEnumerable<UserTask> GetInPgogressTasks()
        {
            return _entities
                .Include(x => x.Status)
                .Where(x => x.Status.Id != (int)UserTaskStatusEnum.Complete)
                .ToList();
        }

        public IEnumerable<UserTask> GetCompletedTasks()
        {
            return _entities
                .Include(x => x.Status)
                .Where(x => x.Status.Id == (int)UserTaskStatusEnum.Complete)
                .ToList();
        }
    }
}
