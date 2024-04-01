namespace ManagementCompany.Models.Alerts
{
    public class AlertViewModel
    {
        public int AlertId { get; set; }

        public string Message { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
