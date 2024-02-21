using ManagementCompany.DbStuff.Models;
using ManagementCompany.Models;

namespace ManagementCompany.DbStuff.Repositories
{
    public class TaskStatusRepository : BaseRepository<UserTaskStatus>
    {
        public TaskStatusRepository(ManagementCompanyDbContext context) : base(context) { }

        public void UpdateStatus(StatusViewModel viewModel, int id)
        {
            var status = _context.TaskStatuses.Single(x => x.Id == id);

            status.Status = viewModel.Status;

            _context.SaveChanges();
        }
    }
}
