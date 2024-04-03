using ManagementCompany.DbStuff.Repositories;

namespace ManagementCompany.BackgroundServices
{
    public class AlertMaintenance : BackgroundService
    {
        public const int ALERT_EXPIRE_FREQUENCY = 60 * 1000;

        private IServiceProvider _services;

        public AlertMaintenance(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var serviceScope = _services.CreateScope();
            
                var _alertRepository = serviceScope.ServiceProvider.GetRequiredService<AlertRepository>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    var markedAlerts = _alertRepository.MarkAsReadAllExpiredAlerts();
                    Console.WriteLine($"Marked alerts: {markedAlerts}");

                    await Task.Delay(ALERT_EXPIRE_FREQUENCY);
                }
            
        }
    }
}
