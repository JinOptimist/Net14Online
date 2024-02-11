
using Net14Web.DbStuff.Models.TaskTracker;
using Net14Web.Models.TaskTracker;
using System.Threading.Tasks;

namespace Net14Web.DbStuff.Repositories.TaskTracker
{
    public class TaskRepository
    {
        private WebDbContext _webDbContext;

        public TaskRepository(WebDbContext context)
        {
            _webDbContext = context;
        }

        public IEnumerable<TaskInfo> GetTasks(int maxCount = 30)
        {
            return _webDbContext.TaskInfos.Take(30).ToList();
        }

        public void DeleteTask(int id)
        {
            var task = _webDbContext.TaskInfos.First(x => x.Id == id);
            _webDbContext.TaskInfos.Remove(task);
            _webDbContext.SaveChanges();

        }

        public TaskInfo GetTaskById(int id)
        {
            return _webDbContext.TaskInfos.First(x => x.Id == id);
        }

        public void UpdateTask(AddTaskViewModel taskViewModel)
        {
            var task = _webDbContext.TaskInfos.First(x => x.Id == taskViewModel.Id);
            task.Name = taskViewModel.Name;
            task.Description = taskViewModel.Description;
            task.Priority = taskViewModel.Priority;
            _webDbContext.SaveChanges();
        }

        public void AddTask(TaskInfo task)
        {
            _webDbContext.TaskInfos.Add(task);
            _webDbContext.SaveChanges();
        }
    }
}
