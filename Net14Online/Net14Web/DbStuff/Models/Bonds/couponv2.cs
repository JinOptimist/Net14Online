namespace Net14Web.DbStuff.Models.Bonds
{
    public class couponv2 : BaseModel
    {
        public DateTime Date { get; set; }

        public int CouponSize { get; set; }

        public virtual Bond Bond { get; set; }
    }
}
