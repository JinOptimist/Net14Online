using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net14Web.DbStuff;
using Net14Web.DbStuff.ManagmentCompany.Models;
using Net14Web.Models.ManagmentCompany;

namespace Net14Web.Controllers
{
    public class ManagmentCompanyController : Controller
    {
        private ManagmentCompanyDbContext _managmentCompanyDbContext;

        public ManagmentCompanyController(ManagmentCompanyDbContext managmentCompanyDbContext)
        {
            _managmentCompanyDbContext = managmentCompanyDbContext;
        }

        public IActionResult Index()
        {
            var dbUsers = _managmentCompanyDbContext
                .Users
                .Include(x => x.MemberPermission)
                .OrderBy(x => x.MemberPermission)
                .ToList();

            var dbAllTasks = _managmentCompanyDbContext
                .UserTasks
                .ToList();

            var dbWorkTasks = _managmentCompanyDbContext
                .UserTasks
                .Include(x => x.Status)
                .Where(x => x.Status.Status != "Выполнена")
                .ToList();

            var dbCompletedTasks = _managmentCompanyDbContext
                .UserTasks
                .Include(x => x.Status)
                .Where(x => x.Status.Status == "Выполнена")
                .ToList();

            var dbProjects = _managmentCompanyDbContext.Projects.ToList();

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
                    Name = dbProject.Name
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

        public IActionResult IndexUsers()
        {
            var dbUsers = _managmentCompanyDbContext
                .Users
                .Include(x => x.MemberPermission)
                .Where(x => x.MemberPermission.Permission == "Пользователь")
                .ToList();

            var dbAllTasks = _managmentCompanyDbContext
                .UserTasks
                .ToList();

            var dbWorkTasks = _managmentCompanyDbContext
                .UserTasks
                .Include(x => x.Status)
                .Where(x => x.Status.Status != "Выполнена")
                .ToList();

            var dbCompletedTasks = _managmentCompanyDbContext
                .UserTasks
                .Include(x => x.Status)
                .Where(x => x.Status.Status == "Выполнена")
                .ToList();

            var dbProjects = _managmentCompanyDbContext.Projects.ToList();

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
                    Name = dbProject.Name
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
            var dbUsers = _managmentCompanyDbContext
                .Users
                .Include(x => x.MemberPermission)
                .Where(x => x.MemberPermission.Permission == "Администратор")
                .ToList();

            var dbAllTasks = _managmentCompanyDbContext
                .UserTasks
                .ToList();

            var dbWorkTasks = _managmentCompanyDbContext
                .UserTasks
                .Include(x => x.Status)
                .Where(x => x.Status.Status != "Выполнена")
                .ToList();

            var dbCompletedTasks = _managmentCompanyDbContext
                .UserTasks
                .Include(x => x.Status)
                .Where(x => x.Status.Status == "Выполнена")
                .ToList();

            var dbProjects = _managmentCompanyDbContext.Projects.ToList();

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
                    Name = dbProject.Name
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

        [HttpGet]
        public IActionResult AdminPanel()
        {
            var viewModel = new AdminPanelViewModel();

            viewModel.Companies = _managmentCompanyDbContext
                .Companies
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            viewModel.Projects = _managmentCompanyDbContext
                .Projects
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();

            viewModel.Permissions = _managmentCompanyDbContext
                .MemberPermissions
                .Select(x => new SelectListItem(x.Permission, x.Id.ToString()))
                .ToList();

            viewModel.Statuses = _managmentCompanyDbContext
                .MemberStatuses
                .Select(x => new SelectListItem(x.Status, x.Id.ToString()))
                .ToList();

            return View(viewModel);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult LogError()
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
                MemberPermission = _managmentCompanyDbContext.MemberPermissions.First(x => x.Permission == "Пользователь")
            };

            _managmentCompanyDbContext.Users.Add(user);

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult AddCompany(CompanyViewModel companyViewModel)
        {
            var company = new Company
            {
                Name = companyViewModel.Name,
                ShortName = companyViewModel.ShortName,
                Email = companyViewModel.Email,
                Adress = companyViewModel.Adress,
                PhoneNumber = companyViewModel.PhoneNumber,
                CompanyStatus = _managmentCompanyDbContext.MemberStatuses.First(x => x.Id == 2)
            };

            _managmentCompanyDbContext.Companies.Add(company);

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult AddProject(ProjectViewModel projectViewModel, int companyId)
        {
            var project = new Project
            {
                Name = projectViewModel.Name,
                ShortName = projectViewModel.ShortName,
                Adress = projectViewModel.Adress,
                ProjectStatus = _managmentCompanyDbContext.MemberStatuses.First(x => x.Id == 2),
                Company = _managmentCompanyDbContext.Companies.First(x => x.Id == companyId)
            };

            _managmentCompanyDbContext.Projects.Add(project);

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult AddExecutor(ExecutorViewModel executorViewModel, int projectId, int permissionId)
        {
            var project = _managmentCompanyDbContext.Projects.First(x => x.Id == projectId);

            var executor = new Executor
            {
                FirstName = executorViewModel.FirstName,
                LastName = executorViewModel.LastName,
                NickName = executorViewModel.NickName,
                Email = executorViewModel.Email,
                PhoneNumber = executorViewModel.PhoneNumber,
                Password = executorViewModel.Password,
                ExpireDate = executorViewModel.ExpireDate,
                MemberPermission = _managmentCompanyDbContext.MemberPermissions.First(x => x.Id == permissionId),
                ExecutorStatus = _managmentCompanyDbContext.MemberStatuses.First(x => x.Id == 2),
            };

            executor.Projects?.Add(project);

            _managmentCompanyDbContext.Executors.Add(executor);

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("AdminPanel");
        }

        [HttpPost]
        public IActionResult RemoveUser(int id)
        {
            var user = _managmentCompanyDbContext.Users.First(x => x.Id == id);

            _managmentCompanyDbContext.Users.Remove(user);

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateUser(int id, string nickName)
        {
            var user = _managmentCompanyDbContext.Users.First(x => x.Id == id);
            user.NickName = nickName;

            _managmentCompanyDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logon(string email, string password)
        {
            var user = _managmentCompanyDbContext.Users.Include(x => x.MemberPermission)
                .FirstOrDefault(x => x.Email == email && x.Password == password);

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
