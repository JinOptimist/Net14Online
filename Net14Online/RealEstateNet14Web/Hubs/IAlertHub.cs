namespace RealEstateNet14Web.Hubs;

public interface IAlertHub
{
    Task PushAlert(string alertMessage,int alertId);
}