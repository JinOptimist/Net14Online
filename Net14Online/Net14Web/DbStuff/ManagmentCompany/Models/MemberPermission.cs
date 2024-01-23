namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class MemberPermission : BaseModel
    {
        public int Id { get; set; }

        public string Permission {  get; set; }

        public List<User>? Users { get; set; }

        public List<Executor>? Executors { get; set; }
    }
}
