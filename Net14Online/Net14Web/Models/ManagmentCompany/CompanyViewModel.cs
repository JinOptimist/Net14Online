namespace Net14Web.DbStuff.ManagmentCompany.Models
{
    public class CompanyViewModel : BaseModel
    {
        public string Name { get; set; }

        public string? ShortName { get; set; }

        public string? Email { get; set; }

        public string? Adress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
