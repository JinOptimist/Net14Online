namespace ManagementCompany.DbStuff.Models
{
    public class MemberStatus : BaseModel
    {
        public string Status { get; set; }

        public virtual List<Company>? Companies { get; set; } = new List<Company>();

        public virtual List<Project>? Projects { get; set; } = new List<Project>();

        public virtual List<User>? Users { get; set; } = new List<User>();
    }
}
