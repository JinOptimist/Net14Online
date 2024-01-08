using System.Collections.Generic;

namespace Net14Web.Models.Movies
{
    public class PersoneViewModel
    {
        public string Login {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl {  get; set; }
        public List<CommentsInPersoneAccount> Comments { get; set; }
    }
}
