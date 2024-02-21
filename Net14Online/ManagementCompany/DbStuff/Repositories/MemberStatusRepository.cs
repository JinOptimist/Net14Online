using ManagementCompany.DbStuff.Models;
using ManagementCompany.Models;

namespace ManagementCompany.DbStuff.Repositories
{
    public class MemberStatusRepository : BaseRepository<MemberStatus>
    {
        public MemberStatusRepository(ManagementCompanyDbContext context) : base(context) { }

        public void UpdateStatus(StatusViewModel viewModel, int id)
        {
            var status = _context.MemberStatuses.Single(x => x.Id == id);

            status.Status = viewModel.Status;

            _context.SaveChanges();
        }
    }
}
