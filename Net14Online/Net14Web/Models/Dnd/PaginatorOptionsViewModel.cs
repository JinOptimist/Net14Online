namespace Net14Web.Models.Dnd
{
    public class PaginatorOptionsViewModel
    {
        public int CurrentPage { get; set; }
        public List<int> AvailablePages { get; set; } = new();

        public int PerPage { get; set; }
        public List<int> AvailablePerPage { get; set; } = new List<int> { 5, 10, 20, 50 };
    }
}