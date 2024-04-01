using Net14Web.DbStuff.Models;
using Net14Web.DbStuff.Models.Movies;
using Net14Web.DbStuff.Repositories;
using Net14Web.Models.Alerts;

namespace Net14Web.Services
{
    public class AlertService
    {
        private readonly AlertRepository _alertRepository;
        private readonly AuthService _authService;

        public AlertService(AlertRepository alertRepository, AuthService authService)
        {
            _alertRepository = alertRepository;
            _authService = authService;
        }

        public List<AlertShortInfoViewModel> GetUnseedAlerts(int userId)
        {
            var userAlerts = _alertRepository.GetUnseedAlerts(userId);
            var alertsForShow = new List<AlertShortInfoViewModel>();
            foreach (var alert in userAlerts)
            {
                var lastDay = alert.CreateDate.Day + alert.DaysOfLive;
                var today = DateTime.Now.Day;

                if (lastDay >= today || alert.IsActualAlert)
                {
                    var alertViewModel = new AlertShortInfoViewModel
                    {
                        Message = alert.Message,
                        AlertId = alert.Id
                    };
                    alertsForShow.Add(alertViewModel);
                }
            }
            return alertsForShow;
        }

        public int Create(string alertMessage, int dayOfLive)
        {
            var newAlter = new Alert
            {
                Creater = _authService.GetCurrentUser(),
                Message = alertMessage,
                IsActualAlert = true,
                CreateDate = DateTime.Now,
            };
            if (dayOfLive > 0)
            {
                newAlter.DaysOfLive = dayOfLive;
                
            }
            
            var alterId = _alertRepository.Add(newAlter);

            return alterId;
        }

        public void MarkAsReaded(int alertId, User user)
        {
            _alertRepository.MarkAsReaded(alertId, user);
        }
    }
}
