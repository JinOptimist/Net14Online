using System.Collections.Generic;

namespace Net14Web.Models.Movies
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Login {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl {  get; set; }
        public List<UserCommentViewModel> Comments { get; set; }
    }
}
