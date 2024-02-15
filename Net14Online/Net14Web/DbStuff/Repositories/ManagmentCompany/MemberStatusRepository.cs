using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.DbStuff.Repositories
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
