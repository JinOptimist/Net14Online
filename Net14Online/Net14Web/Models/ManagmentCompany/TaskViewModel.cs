namespace Net14Web.Models.ManagmentCompany
{
    public class TaskViewModel
    {
        public Guid Guid { get; set; } = Guid.NewGuid();

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
