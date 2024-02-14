using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net14Web.Models.BookingWeb
{
    public class UserSearchViewModel
    {
        public string? UserName { get; set; }
        public List<SelectListItem>? Logins { get; set; }
        public List<SelectListItem>? Searches { get; set; }
    }
}
