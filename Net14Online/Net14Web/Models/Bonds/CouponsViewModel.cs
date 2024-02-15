using Net14Web.DbStuff.Models.Bonds;

namespace Net14Web.Models.Bonds
{
    public class CouponsViewModel
    {
        public DateTime Date { get; set; }

        public int CouponSize { get; set; }

        public string Bond { get; set; }

        public int Id { get; set; }
    }
}
