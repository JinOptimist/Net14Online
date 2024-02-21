namespace ManagementCompany.Models
{
    public class TaskViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public TaskViewModel() : base() { }
    }
}
