using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net14Web.Models.Bonds
{
    public class AddCouponViewModel
    {
        public List<SelectListItem> Bonds { get; set; }
        public int CouponSize { get; set; }
        public DateTime Date { get; set; }
    }
}
