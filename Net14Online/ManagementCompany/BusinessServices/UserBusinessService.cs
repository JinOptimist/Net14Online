using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;
using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Models;

namespace ManagementCompany.BusinessServices
{
    public class UserBusinessService
    {
        private UserRepository _userRepository;
        private CompanyRepository _companyRepository;
        private ProjectRepository _projectRepository;
        private MemberStatusRepository _memberStatusRepository;
        private MemberPermissionRepository _memberPermissionRepository;

        public UserBusinessService(UserRepository userRepository, 
            CompanyRepository companyRepository, 
            ProjectRepository projectRepository, 
            MemberStatusRepository memberStatusRepository, 
            MemberPermissionRepository memberPermissionRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _projectRepository = projectRepository;
            _memberStatusRepository = memberStatusRepository;
            _memberPermissionRepository = memberPermissionRepository;
        }

        public List<UserViewModel> GetUsers()
        {
            var dbUsers = _userRepository.GetUsers();

            var dbManagers = _userRepository.GetManagers();

            var dbAllUsers = dbUsers.Concat(dbManagers);

            var viewModels = dbAllUsers
                .Select(dbUser => new UserViewModel
                {
                    Id = dbUser.Id,
                    NickName = dbUser.NickName,
                    MemberPermission = dbUser.MemberPermission?.Permission,
                })
                .ToList();

            return viewModels;
        }

        public int AddExecutor(ExecutorViewModel executorViewModel/*,int companyId, int projectId, int permissionId*/)
        {
            //var project = _projectRepository.GetById(projectId);

            var executor = new User
            {
                FirstName = executorViewModel.FirstName,
                LastName = executorViewModel.LastName,
                NickName = executorViewModel.NickName,
                Email = executorViewModel.Email,
                PhoneNumber = executorViewModel.PhoneNumber,
                Password = executorViewModel.Password,
                ExpireDate = executorViewModel.ExpireDate,
                //Company = _companyRepository.GetById(companyId),
                //MemberPermission = _memberPermissionRepository.GetById(permissionId),
                Status = _memberStatusRepository.GetById((int)MemberStatusEnum.Active),
            };
            //executor.Projects?.Add(project);

            return _userRepository.Add(executor);
        }

        public void DeleteExecutor(int id)
        {
            _userRepository.Delete(id);
        }
        
    }
}
