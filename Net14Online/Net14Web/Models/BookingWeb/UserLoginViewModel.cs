namespace Net14Web.Models.BookingWeb
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }

        public bool CanDelete { get; set; }

        public string? Owner { get; set; }
    }
}
