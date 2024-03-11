namespace Net14Web.Models.Movies
{
    public class AdminPanelViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<MovieViewModel> Movies { get; set; }

        public bool CanAddMovie { get; set; }
        public bool CanDeleteMovie { get; set; }
        public bool CanUpdateMovie { get; set; }
        public bool CanDeleteUser { get; set; }
        public bool CanUpdateUser { get; set; }
    }
}
