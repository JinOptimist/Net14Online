namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class UserTask
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public User? User { get; set; }
    }
}
