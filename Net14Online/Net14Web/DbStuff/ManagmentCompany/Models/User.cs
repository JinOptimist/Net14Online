namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public MemberStatus? UserStatus { get; set; }

        public MemberPermission? MemberPermission { get; set; }

        public string Password { get; set; }

        public List<UserTask>? UserTasks { get; set; }
    }
}
