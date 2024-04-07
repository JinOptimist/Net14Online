using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealEstateNet14Web.DbStuff.Models;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Hubs;
using RealEstateNet14Web.Services.Auth;

namespace RealEstateNet14Web.Controllers;

[Authorize]
public class AlertController : Controller
{
    private IHubContext<AlertHub, IAlertHub> _alertHub;
    private AlertRepository _alertRepository;
    private RealEstateAuthService _realEstateAuthService;

    public AlertController(IHubContext<AlertHub, IAlertHub> alertHub,
        AlertRepository alertRepository,
        RealEstateAuthService realEstateAuthService)
    {
        _alertHub = alertHub;
        _alertRepository = alertRepository;
        _realEstateAuthService = realEstateAuthService;
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
            Creator = _realEstateAuthService.GetCurrentUser(),
            Message = alertMessage
        };
        
        _alertRepository.Add(alert);
        
       await _alertHub.Clients.All.PushAlert(alertMessage);
       
        return View();
    }
}