namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class MemberStatus : BaseModel
    {
        public string Status { get; set; }

        public virtual List<Company>? Companies { get; set; }

        public virtual List<Project>? Projects { get; set; }

        public virtual List<User>? Users { get; set; }
    }
}
