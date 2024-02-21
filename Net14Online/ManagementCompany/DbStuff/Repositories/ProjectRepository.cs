using ManagementCompany.DbStuff.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementCompany.DbStuff.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(ManagementCompanyDbContext context) : base(context) { }

        public IEnumerable<Project> GetProjectsWithStatus()
        {
            return _entities
                .Include(x => x.Status)
                .Include(x => x.Company)
                .ToList();
        }
    }
}
