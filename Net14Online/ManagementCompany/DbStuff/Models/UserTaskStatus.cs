namespace ManagementCompany.DbStuff.Models
{
    public class UserTaskStatus : BaseModel
    {
        public string Status { get; set; }

        public virtual List<UserTask>? UserTasks { get; set; } = new List<UserTask>();
    }
}
