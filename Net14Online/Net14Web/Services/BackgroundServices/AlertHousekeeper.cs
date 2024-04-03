using Net14Web.DbStuff.Repositories;

namespace Net14Web.Services.BackgroundServices
{
    public class AlertHousekeeper : BackgroundService
    {
        public const int ALERT_EXPIRE_FREQUENCE = 60 * 60 * 1000;
        private IServiceProvider _services;

        public AlertHousekeeper(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var serviceScope = _services.CreateScope();
            var alertRepository = serviceScope.ServiceProvider.GetRequiredService<AlertRepository>();

            while (!stoppingToken.IsCancellationRequested)
            {
                var countOfExpiredAlert = alertRepository.MarkAsReadedAllExpiredAlerts();
                Console.WriteLine($"Mark as readed {countOfExpiredAlert} alers");

                await Task.Delay(ALERT_EXPIRE_FREQUENCE);
            }
        }
    }
}
