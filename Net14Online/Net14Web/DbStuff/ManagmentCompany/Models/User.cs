namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? NickName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? UserRole { get; set; }

        public string? UserPermission { get; set; }

        public string? Password { get; set; }

        public List<UserTask>? UserTasks { get; set; }
    }
}
