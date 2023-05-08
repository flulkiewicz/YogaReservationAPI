namespace YogaReservationAPI.Services.YogaClass
{
    public interface IYogaClassService
    {
        Task<ServiceResponse<GetYogaClassResponseDto>> GetYogaClassById(int id);
        Task<ServiceResponse<List<GetYogaClassResponseDto>>> GetAllYogaClasses();
    }
}
