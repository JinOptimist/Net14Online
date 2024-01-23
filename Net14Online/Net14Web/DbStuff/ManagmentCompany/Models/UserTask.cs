namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class UserTask : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public UserTaskStatus? Status { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public User? Author { get; set; }

        public Executor? Executor { get; set; }
    }
}
