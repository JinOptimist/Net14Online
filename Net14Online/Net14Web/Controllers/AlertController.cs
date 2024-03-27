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

        [HttpGet]
        public IActionResult CreateAlert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlert(string alertMessage)
        {
            var alert = new Alert()
            {
                Creater = _authService.GetCurrentUser(),
                Message = alertMessage,
            };
            _alertRepository.Add(alert);

            await _alertHub.Clients.All.PushAlert(alertMessage, alert.Id);
            return View();
        }
    }
}
