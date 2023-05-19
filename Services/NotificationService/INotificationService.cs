using YogaReservationAPI.Dtos.NotificationsDtos;
using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Services.InstructorService
{
    public interface INotificationService
    {
        Task<ServiceResponse<string>> SendNotificationToUser(int userId, EmailDto emailDto);
        Task<ServiceResponse<List<string>>> SendNotificationToYogaTrainingParticipants(int trainingId, EmailDto emailDto);
        Task<ServiceResponse<List<string>>> SendNotificationToAll(EmailDto emailDto);
    }
}
