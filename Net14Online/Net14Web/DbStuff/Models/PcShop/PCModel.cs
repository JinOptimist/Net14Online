namespace Net14Web.DbStuff.Models.PcShop
{
    public class PCModel : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public CpuModel? CPU { get; set; }
    }
}
