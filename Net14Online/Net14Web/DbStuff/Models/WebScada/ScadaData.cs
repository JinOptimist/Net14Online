using System.ComponentModel.DataAnnotations;

namespace Net14Web.DbStuff.Models.WebScada
{
    public class ScadaData : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public int Cointer { get; set; }
        public string WireBreak { get; set; }
        public string RollingDiesChange { get; set; }

        public virtual SimaticController? UsedController { get; set; }
    }
}
