using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.DbStuff.Repositories
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
