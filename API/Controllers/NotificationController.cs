using Application.Service.Interface;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController: ControllerBase
    {
        private INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetNotificationByUserId(int userId) 
        {
            var notifcation = await _notificationService.GetNotificatioṇByUserIdAsync(userId);
            return Ok(notifcation);

        }

        [HttpDelete("{notificationId}")]
        public async Task<IActionResult> DeleteNotification(int notificationId) 
        {
            await _notificationService.DeleteNotificationAsync(notificationId);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> CreateNotifiCation(NotificationDto notification) 
        { 
            await _notificationService.CreateNotificationAsync(notification);
            return NoContent();
        }
    }
}
