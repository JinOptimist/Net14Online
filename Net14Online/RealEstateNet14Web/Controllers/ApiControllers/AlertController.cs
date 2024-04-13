using Microsoft.AspNetCore.Mvc;
using RealEstateNet14Web.DbStuff.Repositories;
using RealEstateNet14Web.Models.Alerts;
using RealEstateNet14Web.Services.Auth;

namespace RealEstateNet14Web.Controllers.ApiControlers;

[ApiController]
[Route("/api/alert/{action}")]
public class AlertController : Controller
{
    private AlertRepository _alertRepository;
    private RealEstateAuthService _realEstateAuthService;
    
     public AlertController(AlertRepository alertRepository, RealEstateAuthService realEstateAuthService)
     {
            _alertRepository = alertRepository;
            _realEstateAuthService = realEstateAuthService;
     }
     
     
     public List<AlertInfoViewModel> GetExictedAlerts()
     { 
         var userId = _realEstateAuthService.GetCurrentUserId();
         

        return _alertRepository
            .GetUnseedAlerts(userId);
     }
     
     public void MarkAsReaded(int alertId)
     {
         var user = _realEstateAuthService.GetCurrentUser();
         _alertRepository.MarkAsReaded(alertId, user);
     }
}