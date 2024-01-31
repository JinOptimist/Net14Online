using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;

namespace Net14Web.DbStuff.Repositories
{
    public class MemberPermissionRepository : ManagmentCompanyBaseRepository<MemberPermission>
    {
        public MemberPermissionRepository(ManagmentCompanyDbContext context) : base(context) { }
    }
}
