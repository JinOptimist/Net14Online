namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class Project : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ShortName { get; set; }

        public string? Adress { get; set; }

        public MemberStatus? ProjectStatus { get; set; }

        public Company? Company { get; set; }

        public List<Executor>? Executors { get; set; }
    }
}
