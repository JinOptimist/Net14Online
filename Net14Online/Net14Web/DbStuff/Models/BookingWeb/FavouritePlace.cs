using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Models.BookingWeb
{
    public class FavouritePlace: BaseModel
    {
        public string? Country { get; set; }
        public string? City { get; set; }

        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
