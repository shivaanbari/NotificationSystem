using Microsoft.Extensions.Logging;
using NotificationSystem.Enums;
using NotificationSystem.Interfaces;
namespace NotificationSystem.Senders
{
    public class PushNotificationSender : INotificationSender
    {
        public NotificationType Type => NotificationType.Push;
        private readonly ILogger<PushNotificationSender> _logger;

        public PushNotificationSender(ILogger<PushNotificationSender> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(string message)
        {
            _logger.LogInformation("Preparing push send...");
            await Task.Delay(70);
            _logger.LogInformation("Push sent: {Message}", message);
        }
    }
}
