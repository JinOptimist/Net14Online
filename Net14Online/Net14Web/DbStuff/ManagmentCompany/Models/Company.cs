namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class Company : BaseModel
    {
        public string Name { get; set; }

        public string? ShortName { get; set; }

        public string? Email { get; set; }

        public string? Adress { get; set; }

        public string? PhoneNumber { get; set; }

        public virtual MemberStatus? Status { get; set; }

        public virtual List<Project>? Projects { get; set; }

        public virtual List<User>? Executors { get; set; }
    }
}
