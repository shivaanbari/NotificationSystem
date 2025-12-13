using Microsoft.Extensions.Logging;
using NotificationSystem.Enums;
using NotificationSystem.Interfaces;
namespace NotificationSystem.Senders
{
    public class SmsNotificationSender : INotificationSender
    {
        public NotificationType Type => NotificationType.Sms;
        private readonly ILogger<SmsNotificationSender> _logger;

        public SmsNotificationSender(ILogger<SmsNotificationSender> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(string message)
        {
            _logger.LogInformation("Preparing sms send...");
            await Task.Delay(80);
            _logger.LogInformation("SMS sent: {Message}", message);
        }
    }
}
