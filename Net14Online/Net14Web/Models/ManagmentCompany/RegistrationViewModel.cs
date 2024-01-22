using Net14Web.DbStuff.ManagmentCompany.Models;

namespace Net14Web.Models.ManagmentCompany
{
    public class RegistrationViewModel : BaseModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }
    }
}
