namespace ManagementCompany.DbStuff.Models
{
    public class MemberPermission : BaseModel
    {
        public string Permission { get; set; }

        public virtual List<User>? Users { get; set; } = new List<User>();
    }
}
