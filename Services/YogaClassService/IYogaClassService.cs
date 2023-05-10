namespace YogaReservationAPI.Services.YogaClass
{
    public interface IYogaClassService
    {
        Task<ServiceResponse<GetYogaClassResponseDto>> GetYogaClassById(int id);
        Task<ServiceResponse<List<GetYogaClassResponseDto>>> GetAllYogaClasses();
        Task<ServiceResponse<GetYogaClassResponseDto>> AddYogaClass(AddYogaClassRequestDto addYogaClassRequestDto);
        Task<ServiceResponse<GetYogaClassResponseDto>> UpdateYogaClass(UpdateYogaClassRequestDto updateYogaClassRequestDto);
        Task<ServiceResponse<List<GetYogaClassResponseDto>>> DeleteYogaClass(int id);
    }
}
