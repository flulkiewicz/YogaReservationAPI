using YogaReservationAPI.Dtos.YogaTraining;

namespace YogaReservationAPI.Services.YogaTrainingService
{
    public interface IYogaTrainingService
    {
        Task<ServiceResponse<GetYogaTrainingDto>> GetYogaTrainignById(int id);
        Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainings();
        Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainingsByUser(int userId);
        Task<ServiceResponse<GetYogaTrainingDto>> AddYogaTraining(AddYogaTrainingDto addYogaTrainingDto);
        Task<ServiceResponse<GetYogaTrainingDto>> UpdateYogaTraining(UpdateYogaTrainingDto updateYogaTrainingDto, int id);
        Task<ServiceResponse<List<GetYogaTrainingDto>>> DeleteYogaTraining(int id);
        Task<ServiceResponse<GetYogaTrainingDto>> AddUserToTraining(int trainingId, int userId);
        Task<ServiceResponse<GetYogaTrainingDto>> RemoveUserFromTraining(int trainingId, int userId);

    }
}
