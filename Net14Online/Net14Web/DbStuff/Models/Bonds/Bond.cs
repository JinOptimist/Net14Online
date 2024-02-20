using Net14Web.DbStuff.Models.Movies;

namespace Net14Web.DbStuff.Models.Bonds
{
    public class Bond : BaseModel
    {
        public string Name { get; set; }
        public virtual User Owner { get; set; }
        public int Price { get; set; }
        public virtual List<Coupon>? Coupons { get; set; }
    }
}
