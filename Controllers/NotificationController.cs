using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Dtos.NotificationsDtos;
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

        [HttpPost("/user/{userId}")]
        public async Task<ActionResult<ServiceResponse<string>>> SendNotificationToUserById(int userId, EmailDto emailDto)
        {
            return Ok(await _notificationService.SendNotificationToUser(userId, emailDto));
        }

        [HttpPost("/training/{trainingId}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> SendNotificationToYogaTrainingParticipants(int trainingId, EmailDto emailDto)
        {
            return Ok(await _notificationService.SendNotificationToYogaTrainingParticipants(trainingId, emailDto));
        }

        [HttpPost("/all")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> SendNotificationToAllUsers(EmailDto emailDto)
        {
            return Ok(await _notificationService.SendNotificationToAll(emailDto));
        }

    }
}
