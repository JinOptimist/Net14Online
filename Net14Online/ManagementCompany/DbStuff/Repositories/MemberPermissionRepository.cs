using ManagementCompany.DbStuff.Models;
using ManagementCompany.Models;

namespace ManagementCompany.DbStuff.Repositories
{
    public class MemberPermissionRepository : BaseRepository<MemberPermission>
    {
        public MemberPermissionRepository(ManagementCompanyDbContext context) : base(context) { }

        public void UpdatePermission(PermissionViewModel viewModel, int id)
        {
            var permission = _context.MemberPermissions.Single(x => x.Id == id);

            permission.Permission = viewModel.Permission;

            _context.SaveChanges();
        }
    }
}
