using Net14Web.DbStuff.ManagmentCompany.Models;

namespace Net14Web.Models.ManagmentCompany
{
    public class ExecutorViewModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string MemberRole { get; set; }

        public string? MemberPermission { get; set; }

        public string Password { get; set; }

        public DateTime? ExpireDate { get; set; }

        public List<Project>? Projects { get; set; }

        public List<UserTask>? ExecutorTasks { get; set; }
    }
}
