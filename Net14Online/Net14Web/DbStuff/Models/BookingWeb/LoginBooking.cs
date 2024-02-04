namespace Net14Web.DbStuff.Models.BookingWeb
{
    public class LoginBooking : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Search>? Searches { get; set; }
    }
}
