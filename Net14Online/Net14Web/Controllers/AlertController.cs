using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.Hubs;
using Net14Web.Services;

namespace Net14Web.Controllers
{
    [AdminOnly]
    public class AlertController : Controller
    {
        private IHubContext<AlertHub, IAlertHub> _alertHub;
        private AlertService _alertService;
        private AuthService _authService;

        public AlertController(IHubContext<AlertHub, IAlertHub> alertHub,
            AlertService alertService,
            AuthService authService)
        {
            _alertHub = alertHub;
            _alertService = alertService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult CreateAlert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlert(string alertMessage, int alertDay)
        {
           var alertId = _alertService.Create(alertMessage, alertDay);

            await _alertHub.Clients.All.PushAlert(alertMessage, alertId);
            return View();
        }
    }
}
