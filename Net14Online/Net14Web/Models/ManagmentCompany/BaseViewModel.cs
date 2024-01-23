namespace Net14Web.Models.ManagmentCompany
{
    public class BaseViewModel
    {
        public List<ProjectViewModel> Projects { get; set; }

        public List<TaskViewModel> AllTasks { get; set; }

        public List<TaskViewModel> CompletedTasks { get; set; }

        public List<TaskViewModel> WorkInProgressTasks { get; set; }
    }
}
