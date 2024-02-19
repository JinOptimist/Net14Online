using Net14Web.DbStuff.Models.TaskTracker;

namespace Net14Web.Services.TaskTrackerServices
{
    public class TaskPermissions
    {
        private AuthService _authService;

        public TaskPermissions(AuthService authService)
        {
            _authService = authService;
        }
        public bool CanDeleteTask(TaskInfo task)
        {
            return task.Owner is null || task.Owner?.Id == _authService.GetCurrentUserId();
        }
    }
}