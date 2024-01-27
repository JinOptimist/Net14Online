using Microsoft.AspNetCore.Mvc.Rendering;
using Net14Web.DbStuff.Models.InvestPort;
using Net14Web.Models.Dnd;

namespace Net14Web.Models.InvestPortfolio
{
    public class AddDividendViewModel
    {
        public DateTime DateOfReplenishment { get; set; }
        public int TheAmountOfTheDividend { get; set; }
        public List<SelectListItem> Stocks { get; set; }

        //public int IdStock { get; set; }

    }
}
