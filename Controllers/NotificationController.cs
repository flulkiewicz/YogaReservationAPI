using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Services.InstructorService;

namespace YogaReservationAPI.Controllers
{
    [ApiController]
    [Route("/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("/user/{id}")]
        public async Task<ActionResult<ServiceResponse<string>>> SendNotificationToUserById(int id)
        {
            return Ok(await _notificationService.SendNotificationToUser(id));
        }


    }
}
