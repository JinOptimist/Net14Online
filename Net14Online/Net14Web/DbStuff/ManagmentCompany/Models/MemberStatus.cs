namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class MemberStatus : BaseModel
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public List<Company>? Companies { get; set; }

        public List<Project>? Projects { get; set; }

        public List<User>? Users { get; set; }

        public List<Executor>? Executors { get; set; }
    }
}
