namespace Net14Web.DbStuff.Models.InvestPort
{
    public class Stock : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual List<Dividend>? Dividends { get; set; }

    }

}
