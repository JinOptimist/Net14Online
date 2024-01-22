namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class UserTaskStatus : BaseModel
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public List<UserTask>? UserTasks { get; set; }
    }
}
