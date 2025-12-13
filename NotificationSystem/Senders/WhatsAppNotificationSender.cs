using Microsoft.Extensions.Logging;
using NotificationSystem.Enums;
using NotificationSystem.Interfaces;
namespace NotificationSystem.Senders
{
    public class WhatsAppNotificationSender : INotificationSender
    {
        public NotificationType Type => NotificationType.WhatsApp;
        private readonly ILogger<WhatsAppNotificationSender> _logger;

        public WhatsAppNotificationSender(ILogger<WhatsAppNotificationSender> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(string message)
        {
            _logger.LogInformation("Preparing WhatsApp send...");
            await Task.Delay(120);
            _logger.LogInformation("WhatsApp sent: {Message}", message);
        }
    }
}
