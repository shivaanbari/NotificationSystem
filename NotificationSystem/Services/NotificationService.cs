using Microsoft.Extensions.Logging;
using NotificationSystem.Enums;
using NotificationSystem.Interfaces;
namespace NotificationSystem.Services
{
    public class NotificationService
    {
        private readonly IEnumerable<INotificationSender> _senders;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(IEnumerable<INotificationSender> senders,
                                   ILogger<NotificationService> logger)
        {
            _senders = senders;
            _logger = logger;
        }

        public async Task SendAsync(string message, NotificationType type)
        {
            var sender = _senders.FirstOrDefault(s => s.Type == type);
            if (sender == null)
            {
                _logger.LogWarning("No sender found for notification type {Type}", type);
                throw new NotSupportedException($"Notification type {type} is not supported.");
            }

            _logger.LogInformation("Using sender {Sender} for type {Type}", sender.GetType().Name, type);
            await sender.SendAsync(message);
            _logger.LogInformation("Logged: Notification sent using {Type} : {Message}", type, message);
        }
    }
}
