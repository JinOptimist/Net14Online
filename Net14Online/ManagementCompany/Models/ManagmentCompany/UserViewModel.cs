using ManagementCompany.DbStuff.ManagmentCompany.Models;

namespace ManagementCompany.Models.ManagmentCompany
{
    public class UserViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? NickName { get; set; }

        public string? Password { get; set; }

        public string? MemberPermission { get; set; }
    }
}
