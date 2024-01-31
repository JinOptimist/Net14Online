using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.DbStuff.Repositories
{
    public class UserRepository : ManagmentCompanyBaseRepository<User>
    {
        public UserRepository(ManagmentCompanyDbContext context) : base(context) { }

        public override IEnumerable<User> GetAll()
        {
            return _entities
                .Include(x => x.MemberPermission)
                .OrderBy(x => x.MemberPermission)
                .ToList();
        }

        public void UpdateUser(int id, string nickName)
        {
            var user = _context.Users.First(x => x.Id == id);
            user.NickName = nickName;

            _context.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _entities
                .Include(x => x.Status)
                .Include(x => x.MemberPermission)
                .Include(x => x.Company)
                .Where(x => x.MemberPermission.Id == (int)MemberPermissionEnum.User)
                .ToList();
        }

        public IEnumerable<User> GetExecutors()
        {
            return _entities
                .Include(x => x.Status)
                .Include(x => x.MemberPermission)
                .Include(x => x.Company)
                .Where(x => x.MemberPermission.Id != (int)MemberPermissionEnum.User)
                .Where(x => x.MemberPermission.Id != (int)MemberPermissionEnum.SuperAdmin)
                .ToList();
        }

        public IEnumerable<User> GetManagers()
        {
            return _entities
                .Include(x => x.Status)
                .Include(x => x.MemberPermission)
                .Include(x => x.Company)
                .Where(x => x.MemberPermission.Id == (int)MemberPermissionEnum.Manager)
                .ToList();
        }

        public User GetLogUser(string email, string password)
        {
            var user = _context.Users.Include(x => x.MemberPermission)
                .FirstOrDefault(x => x.Email == email && x.Password == password);

            return user;
        }

        public void UpdateExecutor(List<ExecutorViewModel> executorViewModels, int id, int statusId, int companyId, int projectId, int permissionId)
        {
            var executor = _context.Users.First(x => x.Id == id);

            var viewModel = executorViewModels.First();

            var project = _context.Projects.Single(x => x.Id == projectId);

            executor.Id = id;
            executor.FirstName = viewModel.ExecutorFirstName;
            executor.LastName = viewModel.ExecutorLastName;
            executor.NickName = viewModel.ExecutorNickName;
            executor.Email = viewModel.ExecutorEmail;
            executor.PhoneNumber = viewModel.ExecutorPhoneNumber;
            executor.Password = viewModel.ExecutorPassword;
            executor.ExpireDate = viewModel.ExecutorExpireDate;
            executor.MemberPermission = _context.MemberPermissions.Single(x => x.Id == permissionId);
            executor.Company = _context.Companies.Single(x => x.Id != companyId);
            executor.Status = _context.MemberStatuses.Single(x => x.Id == statusId);

            executor.Projects.Add(project);

            _context.SaveChanges();
        }
    }
}
