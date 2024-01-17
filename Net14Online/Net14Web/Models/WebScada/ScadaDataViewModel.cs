namespace Net14Web.Models.WebScada
{
    public class ScadaDataViewModel
    {
        private static int HId { get; set; } = 1;
        
        public int Id { get; set; }
        public string Status { get; set; }
        public int Cointer { get; set; }
        public String WireBreak { get; set; }
        public String RollingDiesChange { get; set; }

        public ScadaDataViewModel()
        {
            Id = HId;
            HId++;
        }
    }
    
}
