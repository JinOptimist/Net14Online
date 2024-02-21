namespace ManagementCompany.Models
{
    public class ProfileViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string? Company { get; set; }

        public List<TaskViewModel>? CurrentUserTasks { get; set; }
    }
}
