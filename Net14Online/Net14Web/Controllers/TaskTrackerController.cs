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
            var viewModel = new AddTaskViewModel
            {
                PriorityOptions = new List<int> { 1, 2, 3 }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddTask(AddTaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                taskViewModel.PriorityOptions = new List<int> { 1, 2, 3 };
                return View(taskViewModel);
            }

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
            var viewModel = new AddTaskViewModel
            {
                Id = dbTask.Id,
                Name = dbTask.Name,
                Description = dbTask.Description,
                Priority = dbTask.Priority,
                PriorityOptions = new List<int> { 1, 2, 3 }

            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateTask(AddTaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                taskViewModel.PriorityOptions = new List<int> { 1, 2, 3 };
                return View(taskViewModel);
            }

            var task = _webDbContext.TaskInfos.First(x => x.Id == taskViewModel.Id);
            task.Name = taskViewModel.Name;
            task.Description = taskViewModel.Description;
            task.Priority = taskViewModel.Priority;
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
