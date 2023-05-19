using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Services.InstructorService
{
    public interface INotificationService
    {
        Task<ServiceResponse<string>> SendNotificationToUser(int id);
        Task<ServiceResponse<string>> SendNotificationToGroup(int id);
        Task<ServiceResponse<string>> SendNotificationToAll(int id);
    }
}
