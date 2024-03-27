using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Net14Web.Controllers.CustomAuthAttributes;
using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Repositories;
using Net14Web.Hubs;
using Net14Web.Services;

namespace Net14Web.Controllers.ApiControlles
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

        public List<string> GetExistedAlerts()
        {
            if (!_authService.IsAuthenticated())
            {
                return new List<string>();
            }

            return _alertRepository
                .GetAll()
                .Select(x => x.Message)
                .ToList();
        }
    }
}
