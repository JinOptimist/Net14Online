using Microsoft.AspNetCore.SignalR;

namespace RealEstateNet14Web.Hubs;

public class AlertHub : Hub<IAlertHub>
{
    public void Test()
    {
        Clients.All.PushAlert("Alert");
    }
}