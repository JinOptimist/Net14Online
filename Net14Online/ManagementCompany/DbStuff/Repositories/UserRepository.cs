using Microsoft.EntityFrameworkCore;
using ManagementCompany.Models;
using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;

namespace ManagementCompany.DbStuff.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(ManagementCompanyDbContext context) : base(context) { }

        public override IEnumerable<User> GetAll()
        {
            return _entities
                .Include(x => x.MemberPermission)
                .OrderBy(x => x.MemberPermission)
                .ToList();
        }

        public void UpdateUser(int id, string nickName)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);
            user.NickName = nickName;

            _context.SaveChanges();
        }

        public void UpdateUser(ProfileViewModel model, int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.Id == id);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.NickName = model.NickName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.Password = model.Password;

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

        public User GetExecutor(int id)
        {
            return _entities
                .Include(x => x.Status)
                .Include(x => x.MemberPermission)
                .Include(x => x.Company)
                .Where(x => x.MemberPermission.Id != (int)MemberPermissionEnum.User)
                .Where(x => x.MemberPermission.Id != (int)MemberPermissionEnum.SuperAdmin)
                .FirstOrDefault(x => x.Id == id);
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
                .SingleOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Password == password);

            return user;
        }

        public void UpdateExecutor(ExecutorViewModel viewModel, int id, int statusId, int companyId, int projectId, int permissionId)
        {
            var executor = _context.Users.Include(x => x.Company).Include(x => x.Status).First(x => x.Id == id);

            //var project = _context.Projects.Include(x => x.Executors).Single(x => x.Id == projectId);

            executor.Id = id;
            executor.FirstName = viewModel.ExecutorFirstName;
            executor.LastName = viewModel.ExecutorLastName;
            executor.NickName = viewModel.ExecutorNickName;
            executor.Email = viewModel.ExecutorEmail;
            executor.PhoneNumber = viewModel.ExecutorPhoneNumber;
            executor.Password = viewModel.ExecutorPassword;
            executor.ExpireDate = viewModel.ExecutorExpireDate;
            executor.MemberPermission = _context.MemberPermissions.Single(x => x.Id == permissionId);
            executor.Company = _context.Companies.Single(x => x.Id == companyId);
            executor.Status = _context.MemberStatuses.Single(x => x.Id == statusId);

            //executor.Projects.Add(project);

            _context.SaveChanges();
        }
    }
}
