using ManagementCompany.DbStuff.Models;
using ManagementCompany.DbStuff.Models.Enums;
using ManagementCompany.DbStuff.Repositories;
using ManagementCompany.Hubs;
using ManagementCompany.Models;
using ManagementCompany.Models.Alerts;
using ManagementCompany.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace ManagementCompany.Controllers
{
    public class AlertController : Controller
    {
        private IHubContext<AlertHub, IAlertHub> _alertHubContext;

        private AlertRepository _alertRepository;

        private AuthService _authService;

        public AlertController(IHubContext<AlertHub, IAlertHub> alertHubContext, AlertRepository alertRepository, AuthService authService)
        {
            _alertHubContext = alertHubContext;
            _alertRepository = alertRepository;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult AddAlert()
        {

            var lastAlerts = _alertRepository.GetLastAlerts();

            var viewModel = new AddAlertViewModel();
            viewModel.IsSuperAdmin = _authService.IsSuperAdmin();

            viewModel.LastAlerts = lastAlerts
                .Select(lastAlert => new AlertViewModel
                {
                    AlertId = lastAlert.Id,
                    Message = lastAlert.Message,
                    CreationDate = lastAlert.CreationDate,
                    ExpireDate = lastAlert.ExpireDate,
                })
                .ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAlert(AddAlertViewModel viewModel, string message, DateTime date)
        {
            var alert = new Alert()
            {
                Message = message,
                ExpireDate = date,
                IsActive = true,
                Author = _authService.GetCurrentMcUser()
            };

            _alertRepository.Add(alert);

            var lastAlerts = _alertRepository.GetLastAlerts();

            viewModel.LastAlerts = lastAlerts
                .Select(lastAlert => new AlertViewModel
                {
                    AlertId = lastAlert.Id,
                    Message = lastAlert.Message,
                    CreationDate = lastAlert.CreationDate,
                    ExpireDate = lastAlert.ExpireDate,
                })
                .ToList();

            await _alertHubContext.Clients.All.PushAlertAsync(message, date, alert.Id);

            viewModel.IsSuperAdmin = _authService.IsSuperAdmin();

            return View(viewModel);
        }
    }
}
