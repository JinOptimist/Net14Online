namespace Net14Web.Hubs
{
    public interface IAlertHub
    {
        Task PushAlert(string message, int alertId);
    }
}