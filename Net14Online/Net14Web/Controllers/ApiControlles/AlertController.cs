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
        private AlertService _alertService;
        private AuthService _authService;

        public AlertController(AlertService alertService, AuthService authService)
        {
            _alertService = alertService;
            _authService = authService;
        }

        public List<AlertShortInfoViewModel> GetExistedAlerts()
        {
            var userId = _authService.GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new List<AlertShortInfoViewModel>();
            }

            return _alertService
                .GetUnseedAlerts(userId.Value);
        }

        public void MarkAsReaded(int alertId)
        {
            var user = _authService.GetCurrentUser();
            _alertService.MarkAsReaded(alertId, user);
        }
    }
}
