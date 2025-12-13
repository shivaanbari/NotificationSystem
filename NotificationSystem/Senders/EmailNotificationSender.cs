using Microsoft.Extensions.Logging;
using NotificationSystem.Enums;
using NotificationSystem.Interfaces;
namespace NotificationSystem.Senders
{

    public class EmailNotificationSender : INotificationSender
    {
        public NotificationType Type => NotificationType.Email;
        private readonly ILogger<EmailNotificationSender> _logger;

        public EmailNotificationSender(ILogger<EmailNotificationSender> logger)
        {
            _logger = logger;
        }

        public async Task SendAsync(string message)
        {
            _logger.LogInformation("Preparing email send...");
            await Task.Delay(100);
            _logger.LogInformation("Email sent: {Message}", message);
        }
    }
}
