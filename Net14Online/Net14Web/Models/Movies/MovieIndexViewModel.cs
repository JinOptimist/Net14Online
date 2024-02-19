namespace Net14Web.Models.Movies
{
    public class MovieIndexViewModel
    {
        public List<MovieViewModel> MovieViewModels { get; set; }
        public int UserId { get; set; }

        public bool CanAccessToAdminPanel { get; set; }
    }
}
