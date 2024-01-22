using Microsoft.AspNetCore.Mvc.Rendering;

namespace Net14Web.Models.ManagmentCompany
{
    public class AdminPanelViewModel
    {
        public List<SelectListItem> Companies { get; set; }

        public List<SelectListItem> Projects { get; set; }

        public List<SelectListItem> Permissions { get; set; }

        public List<SelectListItem> Statuses { get; set; }
    }
}
