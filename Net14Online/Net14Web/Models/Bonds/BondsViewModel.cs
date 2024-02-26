namespace Net14Web.Models.Bonds
{
    public class BondsViewModel
    {
        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool CanDelete { get; set; }

    }
}
