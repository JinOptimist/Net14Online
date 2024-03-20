namespace Net14Web.Models.Bonds
{
    public class CouponsViewModel
    {
        public string OwnerName { get; set; }
        public DateTime Date { get; set; }
        public int CouponSize { get; set; }
        public string Bond { get; set; }
        public int Id { get; set; }
        public bool CanDelete { get; set; }
    }
}
