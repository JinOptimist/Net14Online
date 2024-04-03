using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.Hubs;
using Net14Web.Models.Alerts;
using Net14Web.Services;

namespace Net14Web.Controllers.ApiControlles
{
    [ApiController]
    [Route("/api/alert/{action}")]
    public class AlertController : Controller
    {
        private IHubContext<AlertHub, IAlertHub> _alertHub;
        private AlertRepository _alertRepository;
        private AuthService _authService;

        public AlertController(IHubContext<AlertHub, IAlertHub> alertHub,
            AlertRepository alertRepository,
            AuthService authService)
        {
            _alertHub = alertHub;
            _alertRepository = alertRepository;
            _authService = authService;
        }

        public List<AlertShortInfoViewModel> GetExistedAlerts()
        {
            var userId = _authService.GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new List<AlertShortInfoViewModel>();
            }

            return _alertRepository
                .GetUnseedAlerts(userId.Value);
        }

        public void MarkAsReaded(int alertId)
        {
            var user = _authService.GetCurrentUser();
            _alertRepository.MarkAsReaded(alertId, user);
        }
    }
}
