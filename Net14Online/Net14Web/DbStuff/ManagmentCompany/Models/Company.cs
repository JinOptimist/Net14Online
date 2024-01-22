namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class Company : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? ShortName { get; set; }

        public string? Email { get; set; }

        public string? Adress { get; set; }

        public string? PhoneNumber { get; set; }

        public MemberStatus? CompanyStatus { get; set; }

        public List<Project>? Projects { get; set; }
    }
}
