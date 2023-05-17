using YogaReservationAPI.Dtos.YogaTraining;

namespace YogaReservationAPI.Services.YogaTrainingService
{
    public interface IYogaTrainingService
    {
        Task<ServiceResponse<GetYogaTrainingDto>> GetYogaTrainignById(int id);
        Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainings();
        Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainingByUser(int userId);
        Task<ServiceResponse<GetYogaTrainingDto>> AddYogaTraining(AddYogaTrainingDto addYogaTrainingDto);
        Task<ServiceResponse<GetYogaTrainingDto>> UpdateYogaTraining(YogaTraining yogaTraining);
        Task<ServiceResponse<GetYogaTrainingDto>> RemoveYogaTraining(int id);

    }
}
