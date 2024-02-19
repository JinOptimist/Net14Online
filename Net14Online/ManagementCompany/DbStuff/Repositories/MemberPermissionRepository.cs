using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.ManagmentCompany.Models;
using ManagementCompany.DbStuff.ManagmentCompany.Models.Enums;
using ManagementCompany.Models.ManagmentCompany;

namespace ManagementCompany.DbStuff.Repositories
{
    public class MemberPermissionRepository : ManagmentCompanyBaseRepository<MemberPermission>
    {
        public MemberPermissionRepository(ManagmentCompanyDbContext context) : base(context) { }

        public void UpdatePermission(PermissionViewModel viewModel, int id)
        {
            var permission = _context.MemberPermissions.Single(x => x.Id == id);

            permission.Permission = viewModel.Permission;

            _context.SaveChanges();
        }
    }
}
