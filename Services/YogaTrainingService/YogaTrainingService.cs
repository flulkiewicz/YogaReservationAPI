using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Data;
using YogaReservationAPI.Dtos.YogaTraining;

namespace YogaReservationAPI.Services.YogaTrainingService
{
    public class YogaTrainingService : IYogaTrainingService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public YogaTrainingService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetYogaTrainingDto>> AddYogaTraining(AddYogaTrainingDto addYogaTrainingDto)
        {
            var response = new ServiceResponse<GetYogaTrainingDto>();

            if(addYogaTrainingDto.Date < DateTime.Now)
            {
                response.Message = "Data cant be in past";
                response.Success = false;
                return response;
            }

            var yogaClass = _mapper.Map<YogaTraining>(addYogaTrainingDto);

            _context.Add(yogaClass);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetYogaTrainingDto>(yogaClass);
            response.Message = "Training has beed added.";

            return response;
        }

        public async Task<ServiceResponse<GetYogaTrainingDto>> GetYogaTrainignById(int id)
        {
            var response = new ServiceResponse<GetYogaTrainingDto>();

            var yogaClass = await _context.YogaTrainings.FirstOrDefaultAsync(x => x.Id == id);

            if(yogaClass != null)
                throw new Exception($"Yoga class with given id: {id} not exists.");

            response.Data = _mapper.Map<GetYogaTrainingDto>(yogaClass);

            return response;
        }

        public Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainingByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainings()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetYogaTrainingDto>> RemoveYogaTraining(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetYogaTrainingDto>> UpdateYogaTraining(YogaTraining yogaTraining)
        {
            throw new NotImplementedException();
        }
    }
}
