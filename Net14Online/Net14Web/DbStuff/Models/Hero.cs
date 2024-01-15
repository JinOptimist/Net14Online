namespace Net14Web.DbStuff.Models
{
    public class Hero : BaseModel
    {
        public string Name { get; set; }
        public int Coins { get; set; }
        public int Hp {  get; set; }
        public DateTime Birthday { get; set; }
    }
}
