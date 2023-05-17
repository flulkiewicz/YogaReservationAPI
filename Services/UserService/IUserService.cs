using System.Runtime.CompilerServices;
using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserFullInfoDto>> GetUserFullInfoById(int id);
        
    }
}
