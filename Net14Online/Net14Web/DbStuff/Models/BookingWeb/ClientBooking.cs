using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Models.BookingWeb
{
    public class ClientBooking : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual User? Owner { get; set; }
        public virtual List<Search>? Searches { get; set; }
    }
}
