namespace Net14Web.DbStuff.Models.LifeScore
{
    public class Player : BaseModel
    {
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public int TeamId{ get; set; }
        public int Goals{ get; set; }
        public int Assists{ get; set; }

        public virtual Team Team { get; set; }
    }
}
