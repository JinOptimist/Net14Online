using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;

namespace Net14Web.DbStuff.Repositories
{
    public class ProjectRepository : ManagmentCompanyBaseRepository<Project>
    {
        public ProjectRepository(ManagmentCompanyDbContext context) : base(context) { }

        public IEnumerable<Project> GetProjectsWithStatus()
        {
            return _entities
                .Include(x => x.Status)
                .Include(x => x.Company)
                .ToList();
        }
    }
}
