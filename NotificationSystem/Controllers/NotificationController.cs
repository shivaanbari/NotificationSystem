using Microsoft.AspNetCore.Mvc;
using NotificationSystem.Enums;
using NotificationSystem.Services;

namespace NotificationSystem.Controllers
{
    [ApiController]
    [Route("api/notify")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] NotificationType type, [FromBody] string message)
        {
            await _notificationService.SendAsync(message, type);
            return Ok();
        }
    }

}
