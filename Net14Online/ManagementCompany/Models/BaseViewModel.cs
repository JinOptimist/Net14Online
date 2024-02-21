namespace ManagementCompany.Models
{
    public class BaseViewModel
    {
        public DateTime? CreationDate { get; set; }

        internal List<ProjectViewModel> Projects { get; set; }

        internal List<TaskViewModel> AllTasks { get; set; }

        internal List<TaskViewModel> CompletedTasks { get; set; }

        internal List<TaskViewModel> WorkInProgressTasks { get; set; }

        internal Dictionary<string, string> AdminPages { get; set; } = new Dictionary<string, string>
        {
            { "Index", "На главную" } ,
            { "About", "О нас" },
            { "Contacts", "Контакты" },
            { "Profile", "Профиль" },
            { "AdminPanel", "Панель управления" }
        };

        internal Dictionary<string, string> UserPages { get; } = new Dictionary<string, string>
        {
            { "AddTask", "Создать заявку" } ,
            { "Index", "На главную" } ,
            { "About", "О нас" },
            { "Contacts", "Контакты" },
            { "Profile", "Профиль" }
        };

        internal Dictionary<string, string> GuestPages { get; } = new Dictionary<string, string>
        {
            { "Index", "На главную" } ,
            { "About", "О нас" },
            { "Contacts", "Контакты" },
        };

        public BaseViewModel()
        {
            CreationDate = DateTime.Now;
        }
    }
}
