using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net14Web.Models.InvestPortfolio
{
    public class AddDividendViewModel
    {
        public DateTime DateOfReplenishment { get; set; }
        public int TheAmountOfTheDividend { get; set; }
        public List<SelectListItem> Stocks { get; set; }

    }

}
