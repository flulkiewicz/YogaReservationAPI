using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Data.Auth
{
    public interface IAuthRepository
    {
        Task<bool> UserExists(string email);
        Task<ServiceResponse<int>> Register(UserRegisterDto userRegisterDto);
        Task<ServiceResponse<string>> Login(string email, string password);
    }
}
