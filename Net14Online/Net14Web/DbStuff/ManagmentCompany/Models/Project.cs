namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class Project : BaseModel
    {
        public string Name { get; set; }

        public string? ShortName { get; set; }

        public string? Adress { get; set; }

        public virtual MemberStatus? Status { get; set; }

        public virtual Company? Company { get; set; }

        public virtual List<User>? Executors { get; set; }
    }
}
