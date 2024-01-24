using Net14Web.DbStuff.Models.InvestPort;

namespace Net14Web.DbStuff.Models
{
    public class Dividend : BaseModel
    {
        public DateTime DateOfReplenishment { get; set; }
        public int TheAmountOfTheDividend { get; set; }
        public virtual Stock Stock { get; set; }
    }

}
