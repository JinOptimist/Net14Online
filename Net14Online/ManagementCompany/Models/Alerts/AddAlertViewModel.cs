namespace ManagementCompany.Models.Alerts
{
    public class AddAlertViewModel
    {
        public bool IsSuperAdmin { get; set; }

        public List<AlertViewModel> LastAlerts { get; set; }
    }
}
