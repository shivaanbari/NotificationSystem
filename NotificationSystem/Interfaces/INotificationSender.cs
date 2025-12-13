using NotificationSystem.Enums;

namespace NotificationSystem.Interfaces
{
    public interface INotificationSender
    {
        NotificationType Type { get; }
        Task SendAsync(string message);
    }
}
