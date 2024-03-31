using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Models.Alerts;
using ManagementCompany.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManagementCompany.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/alert/{action}")]
    public class AlertController : Controller
    {
        private AlertRepository _alertRepository;
        private AuthService _authService;

        public AlertController(AlertRepository alertRepository, AuthService authService)
        {
            _alertRepository = alertRepository;
            _authService = authService;
        }

        public List<AlertViewModel> GetExistedAlerts()
        {
            var userId = _authService.GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new List<AlertViewModel>();
            }
            return _alertRepository.GetUnreadAndActualAlerts(userId.Value);
        }

        public void MarkAsRead(int alertId)
        {
            var user = _authService.GetCurrentUser();

            _alertRepository.MarkAsRead(user, alertId);
        }

        public void DeleteAlert(int alertId)
        {
            _alertRepository.Delete(alertId);
        }
    }
}
