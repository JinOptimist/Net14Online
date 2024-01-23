using Microsoft.AspNetCore.Mvc;
using Net14Web.DbStuff;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net14Web.Models.TaskTracker;
using Net14Web.Services;
using System.Xml.Linq;
using Net14Web.DbStuff.Models.TaskTracker;

namespace Net14Web.Controllers
{
    public class TaskTrackerController : Controller
    {
        public static List<TaskViewModel> taskViewModels = new List<TaskViewModel>();
        private WebDbContext _webDbContext;

        public TaskTrackerController(WebDbContext webDbContext)
        {
            _webDbContext = webDbContext;
        }

        public IActionResult Index()
        {
            var dbTasks = _webDbContext.TaskInfos.Take(30).ToList();
            var viewModels = dbTasks.Select(dbTask => new TaskViewModel
            {
                Id = dbTask.Id,
                Name = dbTask.Name,
                Description = dbTask.Description,
                Priority = dbTask.Priority,

            }).ToList();
            return View(viewModels);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskViewModel taskViewModel)
        {
            var task = new TaskInfo
            {
                Name = taskViewModel.Name,
                Description = taskViewModel.Description,
                Priority = taskViewModel.Priority
            };

            _webDbContext.TaskInfos.Add(task);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            var dbTask = _webDbContext.TaskInfos.First(x => x.Id == id);
            var viewModel = new TaskViewModel
            {
                Id = dbTask.Id,
                Name = dbTask.Name,
                Description = dbTask.Description,
                Priority = dbTask.Priority,

            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateTask(int id, string name, string description, int priority)
        {
            var task = _webDbContext.TaskInfos.First(x => x.Id == id);
            task.Name = name;
            task.Description = description;
            task.Priority = priority;
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int id)
        {
            var task = _webDbContext.TaskInfos.First(x => x.Id == id);
            _webDbContext.TaskInfos.Remove(task);
            _webDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
