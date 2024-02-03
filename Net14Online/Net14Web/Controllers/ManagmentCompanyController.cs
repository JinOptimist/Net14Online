using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.DbStuff.ManagmentCompany.Models.Enums;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.Controllers
{
    public class ManagmentCompanyController : Controller
    {
        private CompanyRepository _companyRepository;
        private ProjectRepository _projectRepository;
        private UserRepository _userRepository;
        private UserTaskRepository _userTaskRepository;
        private MemberPermissionRepository _memberPermissionRepository;
        private MemberStatusRepository _memberStatusRepository;

        public ManagmentCompanyController(
            CompanyRepository companyRepository,
            ProjectRepository projectRepository,
            UserRepository userRepository,
            UserTaskRepository userTaskRepository,
             MemberPermissionRepository memberPermissionRepository,
             MemberStatusRepository memberStatusRepository)
        {
            _companyRepository = companyRepository;
            _projectRepository = projectRepository;
            _userRepository = userRepository;
            _userTaskRepository = userTaskRepository;
            _memberPermissionRepository = memberPermissionRepository;
            _memberStatusRepository = memberStatusRepository;
        }

        public IActionResult Index()
        {
            var dbUsers = _userRepository.GetUsers();

            var dbManagers = _userRepository.GetManagers();

            var dbAllUsers = dbUsers.Concat(dbManagers);

            var dbAllTasks = _userTaskRepository.GetAll()
                .ToList();

            var dbWorkTasks = _userTaskRepository.GetInPgogressTasks();

            var dbCompletedTasks = _userTaskRepository.GetCompletedTasks();

            var dbProjects = _projectRepository
                .GetAll();

            var viewModel = new IndexViewModel();

            viewModel.AllTasks = dbAllTasks
                .Select(dbAllTask => new TaskViewModel
                {
                    Name = dbAllTask.Name
                })
                .ToList();

            viewModel.WorkInProgressTasks = dbWorkTasks
                .Select(dbWorkTask => new TaskViewModel
                {
                    Name = dbWorkTask.Name
                })
                .ToList();

            viewModel.CompletedTasks = dbCompletedTasks
                .Select(dbCompletedTask => new TaskViewModel
                {
                    Name = dbCompletedTask.Name
                })
                .ToList();

            viewModel.Projects = dbProjects
                .Select(dbProject => new ProjectViewModel
                {
                    ProjectName = dbProject.Name
                })
                .ToList();

            viewModel.Users =
                dbAllUsers
                .Select(dbUser => new UserViewModel
                {
                    Id = dbUser.Id,
                    NickName = dbUser.NickName,
                    MemberPermission = dbUser.MemberPermission?.Permission,
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult IndexUsers()
        {
            var dbUsers = _userRepository.GetUsers();

            var dbAllTasks = _userTaskRepository.GetAll();

            var dbWorkTasks = _userTaskRepository.GetInPgogressTasks();

            var dbCompletedTasks = _userTaskRepository.GetCompletedTasks();

            var dbProjects = _projectRepository.GetAll();

            var viewModel = new IndexViewModel();

            viewModel.AllTasks = dbAllTasks
                .Select(dbAllTask => new TaskViewModel
                {
                    Name = dbAllTask.Name
                })
                .ToList();

            viewModel.WorkInProgressTasks = dbWorkTasks
                .Select(dbWorkTask => new TaskViewModel
                {
                    Name = dbWorkTask.Name
                })
                .ToList();

            viewModel.CompletedTasks = dbCompletedTasks
                .Select(dbCompletedTask => new TaskViewModel
                {
                    Name = dbCompletedTask.Name
                })
                .ToList();

            viewModel.Projects = dbProjects
                .Select(dbProject => new ProjectViewModel
                {
                    ProjectName = dbProject.Name
                })
                .ToList();

            viewModel.Users =
                dbUsers
                .Select(dbUser => new UserViewModel
                {
                    Id = dbUser.Id,
                    NickName = dbUser.NickName,
                    MemberPermission = dbUser.MemberPermission?.Permission,
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult IndexAdmins()
        {
            var dbUsers = _userRepository.GetManagers();

            var dbAllTasks = _userTaskRepository.GetAll();

            var dbWorkTasks = _userTaskRepository.GetInPgogressTasks();

            var dbCompletedTasks = _userTaskRepository.GetCompletedTasks();

            var dbProjects = _projectRepository.GetAll();

            var viewModel = new IndexViewModel();

            viewModel.AllTasks = dbAllTasks
                .Select(dbAllTask => new TaskViewModel
                {
                    Name = dbAllTask.Name
                })
                .ToList();

            viewModel.WorkInProgressTasks = dbWorkTasks
                .Select(dbWorkTask => new TaskViewModel
                {
                    Name = dbWorkTask.Name
                })
                .ToList();

            viewModel.CompletedTasks = dbCompletedTasks
                .Select(dbCompletedTask => new TaskViewModel
                {
                    Name = dbCompletedTask.Name
                })
                .ToList();

            viewModel.Projects = dbProjects
                .Select(dbProject => new ProjectViewModel
                {
                    ProjectName = dbProject.Name
                })
                .ToList();

            viewModel.Users =
                dbUsers
                .Select(dbUser => new UserViewModel
                {
                    Id = dbUser.Id,
                    NickName = dbUser.NickName,
                    MemberPermission = dbUser.MemberPermission?.Permission,
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult LogError()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminPanel()
        {
            var dbCompanies = _companyRepository.GetCompaniesWithStatus();

            var dbProjects = _projectRepository.GetProjectsWithStatus();

            var dbExecuters = _userRepository.GetExecutors();

            var viewModel = new AdminPanelViewModel();

            viewModel.Companies = dbCompanies
                .Select(dbCompany => new CompanyViewModel
                {
                    Id = dbCompany.Id,
                    CompanyName = dbCompany.Name,
                    CompanyShortName = dbCompany.ShortName,
                    CompanyAdress = dbCompany.Adress,
                    CompanyEmail = dbCompany.Email,
                    CompanyPhoneNumber = dbCompany.PhoneNumber,
                    CompanyStatus = dbCompany.Status.Status
                })
                .ToList();

            viewModel.Projects = dbProjects
                .Select(dbProject => new ProjectViewModel
                {
                    Id = dbProject.Id,
                    ProjectName = dbProject.Name,
                    ProjectShortName = dbProject.ShortName,
                    ProjectAdress = dbProject.Adress,
                    ProjectStatus = dbProject.Status.Status,
                    ProjectLinkCompany = dbProject.Company.Name
                })
                .ToList();

            viewModel.Executors = dbExecuters
                .Select(dbExecuter => new ExecutorViewModel
                {
                    Id = dbExecuter.Id,
                    ExecutorFirstName = dbExecuter.FirstName,
                    ExecutorLastName = dbExecuter.LastName,
                    ExecutorNickName = dbExecuter.NickName,
                    ExecutorEmail = dbExecuter.Email,
                    ExecutorPhoneNumber = dbExecuter.PhoneNumber,
                    ExecutorExpireDate = dbExecuter.ExpireDate,
                    //Company = dbExecuter.Company.Name,
                    ExecutorMemberPermission = _memberPermissionRepository.GetById(dbExecuter.MemberPermission.Id).Permission,
                    ExecutorMemberStatus = _memberStatusRepository.GetById(dbExecuter.Status.Id).Status
                })
                .ToList();

            return View(viewModel);
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registrationViewModel);
            }

            var user = new User
            {
                Email = registrationViewModel.Email,
                NickName = registrationViewModel.NickName,
                Password = registrationViewModel.Password,
                MemberPermission = _memberPermissionRepository.GetById((int)MemberPermissionEnum.User),
                Status = _memberStatusRepository.GetById((int)MemberStatusEnum.Active)
            };
            _userRepository.Add(user);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCompany(CompanyViewModel companyViewModel)
        {
            companyViewModel.Companies = _companyRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            companyViewModel.Projects = _projectRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            companyViewModel.Permissions = _memberPermissionRepository.GetAll()
                .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                .ToList();

            companyViewModel.Statuses = _memberStatusRepository.GetAll()
                .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                .ToList();

            var company = new Company
            {
                Name = companyViewModel.CompanyName,
                ShortName = companyViewModel.CompanyShortName,
                Email = companyViewModel.CompanyEmail,
                Adress = companyViewModel.CompanyAdress,
                PhoneNumber = companyViewModel.CompanyPhoneNumber,
                Status = _memberStatusRepository.GetById((int)MemberStatusEnum.Active)
            };

            _companyRepository.Add(company);

            return RedirectToAction("AdminPanel");
        }

        [HttpGet]
        public IActionResult UpdateCompany(int id)
        {
            var company = _companyRepository.GetCompaniesWithStatus()
                .First(x => x.Id == id);

            var viewModel = new CompanyViewModel

            {
                Id = company.Id,
                CompanyName = company.Name,
                CompanyShortName = company.ShortName,
                CompanyAdress = company.Adress,
                CompanyEmail = company.Email,
                CompanyPhoneNumber = company.PhoneNumber,
                CompanyStatus = company.Status.Status,
                Statuses = _memberStatusRepository.GetAll()
                    .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateCompany(CompanyViewModel companyViewModels, int id, int statusId)
        {
            _companyRepository.UpdateCompany(companyViewModels, id, statusId);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult RemoveCompany(int id)
        {
            _companyRepository.Delete(id);

            return RedirectToAction("AdminPanel");
        }

        [HttpGet]
        public IActionResult AddProject()
        {
            ProjectViewModel projectViewModel = new ProjectViewModel();

            projectViewModel.Companies = _companyRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            projectViewModel.Projects = _projectRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            projectViewModel.Permissions = _memberPermissionRepository.GetAll()
                .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                .ToList();

            projectViewModel.Statuses = _memberStatusRepository.GetAll()
                .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                .ToList();

            return View(projectViewModel);
        }

        [HttpPost]
        public IActionResult AddProject(ProjectViewModel projectViewModel, int companyId)
        {
            projectViewModel.Companies = _companyRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            projectViewModel.Projects = _projectRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            projectViewModel.Permissions = _memberPermissionRepository.GetAll()
                .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                .ToList();

            projectViewModel.Statuses = _memberStatusRepository.GetAll()
                .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                .ToList();

            var project = new Project
            {
                Name = projectViewModel.ProjectName,
                ShortName = projectViewModel.ProjectShortName,
                Adress = projectViewModel.ProjectAdress,
                Status = _memberStatusRepository.GetById((int)MemberStatusEnum.Active),
                Company = _companyRepository.GetById(companyId)
            };

            _projectRepository.Add(project);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult RemoveProject(int id)
        {
            _projectRepository.Delete(id);

            return RedirectToAction("AdminPanel");
        }

        [HttpGet]
        public IActionResult AddExecutor()
        {
            var executorViewModel = new ExecutorViewModel();

            executorViewModel.Companies = _companyRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            executorViewModel.Projects = _projectRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            executorViewModel.Permissions = _memberPermissionRepository.GetAll()
                .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                .ToList();

            executorViewModel.Statuses = _memberStatusRepository.GetAll()
                .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                .ToList();

            return View(executorViewModel);
        }

        [HttpPost]
        public IActionResult AddExecutor(ExecutorViewModel executorViewModel, int companyId, int projectId, int permissionId)
        {
            executorViewModel.Companies = _companyRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            executorViewModel.Projects = _projectRepository.GetAll()
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            executorViewModel.Permissions = _memberPermissionRepository.GetAll()
                .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                .ToList();

            executorViewModel.Statuses = _memberStatusRepository.GetAll()
                .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                .ToList();

            var project = _projectRepository.GetById(projectId);

            var executor = new User
            {
                FirstName = executorViewModel.ExecutorFirstName,
                LastName = executorViewModel.ExecutorLastName,
                NickName = executorViewModel.ExecutorNickName,
                Email = executorViewModel.ExecutorEmail,
                PhoneNumber = executorViewModel.ExecutorPhoneNumber,
                Password = executorViewModel.ExecutorPassword,
                ExpireDate = executorViewModel.ExecutorExpireDate,
                Company = _companyRepository.GetById(companyId),
                MemberPermission = _memberPermissionRepository.GetById(permissionId),
                Status = _memberStatusRepository.GetById((int)MemberStatusEnum.Active),
            };
            executor.Projects?.Add(project);

            _userRepository.Add(executor);

            return RedirectToAction("AdminPanel");
        }

        [HttpGet]
        public IActionResult UpdateExecutor(int id)
        {
            var viewModel = new ExecutorViewModel();

            if (id != 0)
            {
                var user = _userRepository.GetExecutor(id);
                //.ToList();

                viewModel.Id = user.Id;
                viewModel.ExecutorFirstName = user.FirstName;
                viewModel.ExecutorLastName = user.LastName;
                viewModel.ExecutorEmail = user.Email;
                viewModel.ExecutorPhoneNumber = user.PhoneNumber;
                viewModel.ExecutorExpireDate = user.ExpireDate;
                viewModel.ExecutorPassword = user.Password;
                viewModel.ExecutorMemberPermission = user.MemberPermission.Permission;
                viewModel.ExecutorMemberStatus = user.Status.Status;
                viewModel.ExecutorNickName = user.NickName;
                viewModel.Company = user.Company.Name;
                viewModel.Companies = _companyRepository.GetAll()
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();
                viewModel.Projects = _projectRepository.GetAll()
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToList();
                viewModel.Statuses = _memberStatusRepository.GetAll()
                    .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                    .ToList();
                viewModel.Permissions = _memberPermissionRepository.GetAll()
                    .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                    .ToList();

            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateExecutor(ExecutorViewModel executorViewModels, int id, int statusId, int companyId, int projectId, int permissionId)
        {
            _userRepository.UpdateExecutor(executorViewModels, id, statusId, companyId, projectId, permissionId);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult RemoveExecutor(int id)
        {
            _userRepository.Delete(id);

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult RemoveUser(int id)
        {
            _userRepository.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, string nickName)
        {
            _userRepository.UpdateUser(id, nickName);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logon(string email, string password)
        {
            var user = _userRepository.GetLogUser(email, password);

            if (user == null)
            {
                return RedirectToAction("LogError");
            }

            if (user.MemberPermission?.Permission == "Пользователь")
            {
                return RedirectToAction("Profile");
            }
            else
            {
                return RedirectToAction("AdminPanel");
            }
        }

        private List<string> GetAdminPages()
        {
            return new List<string>
        {
            "Index",
            "IndexUsers",
            "IndexAdmins",
            "About",
            "Contacts",
            "Logout",
            "Profile",
            "AdminPanel"
        };
        }

        private List<string> GetUserPages()
        {
            return new List<string>
        {
            "Index",
            "IndexUsers",
            "IndexAdmins",
            "About",
            "Contacts",
            "Logout",
            "Profile"
        };
        }

        private List<string> GetGuestPages()
        {
            return new List<string>
        {
            "Index",
            "IndexUsers",
            "IndexAdmins",
            "About",
            "Contacts",
            "Login",
            "Registration"
        };
        }
    }
}
