namespace Net14Web.DbStuff.Models.PcShop
{
    public class CpuModel : BaseModel
    {
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public override string ToString()
        {
            return $"{Manufacturer} {Model}" ;
        }
        public string? Generation { get; set; }
        public string Socket { get; set; } = null!;
        public int Frequency { get; set; }
        public int Cores { get; set; }
        public int Threads { get; set; }
        public float Price { get; set; }
    }
}
