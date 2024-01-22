using System.ComponentModel.DataAnnotations;

namespace Net14Web.DbStuff.Models.WebScada
{
    public class SimaticController
    {
        [Key]
        public int Id { get; set; }
        public string IpAdress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public virtual List<ScadaData>? ScadaData { get; set; }
    }
}