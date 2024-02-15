namespace Net14Web.DbStuff.Models.Bonds
{
    public class Bond : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual List<Coupon>? Coupons { get; set; }

    }
}
