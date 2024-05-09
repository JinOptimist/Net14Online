using Net14Web.DbStuff.Models.Bonds;
using Net14Web.DbStuff.Models.BookingWeb;
using Net14Web.DbStuff.Models.TaskTracker;

namespace Net14Web.DbStuff.Models.Movies
{
    public class User : BaseModel
    {
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? AvatarUrl { get; set; }
        public string PreferLocale { get; set; }
        public virtual List<Role> Roles { get; set; }
        public virtual List<Comment>? Comments { get; set; }
        public virtual List<Hero>? MyHeroes { get; set; }
        public virtual List<TaskInfo> TaskInfos { get; set; }
        public virtual List<ClientBooking>? ClientsBooking { get; set; }
        public virtual List<Search>? Searches { get; set; }

        public virtual List<FavouritePlace> FavouritePlaces { get; set; }

        public virtual List<Bond> Bonds { get; set; }

        public virtual List<Alert> SeenAlerts { get; set; }
        public virtual List<Alert> CreatedAlerts { get; set; }
    }
}
