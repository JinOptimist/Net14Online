using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.ManagmentCompany.Models;
using ManagementCompany.DbStuff.ManagmentCompany.Models.Enums;
using ManagementCompany.Models.ManagmentCompany;

namespace ManagementCompany.DbStuff.Repositories
{
    public class MemberStatusRepository : ManagmentCompanyBaseRepository<MemberStatus>
    {
        public MemberStatusRepository(ManagmentCompanyDbContext context) : base(context) { }

        public void UpdateStatus(StatusViewModel viewModel, int id)
        {
            var status = _context.MemberStatuses.Single(x => x.Id == id);

            status.Status = viewModel.Status;

            _context.SaveChanges();
        }
    }
}
