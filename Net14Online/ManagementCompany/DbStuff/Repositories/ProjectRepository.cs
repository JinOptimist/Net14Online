using Microsoft.EntityFrameworkCore;
using ManagementCompany.DbStuff.ManagmentCompany.Models;
using ManagementCompany.DbStuff.ManagmentCompany.Models.Enums;

namespace ManagementCompany.DbStuff.Repositories
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
