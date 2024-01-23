namespace Net14Web.DbStuff.Models.TaskTracker
{
    public class TaskInfo : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

    }
}
