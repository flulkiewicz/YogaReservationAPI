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

            var yogaTraining = await _context.YogaTrainings
                .Include(y => y.Location)
                .FirstOrDefaultAsync(y => y.Id == id);

            if (yogaTraining == null)
                throw new NotFoundException($"Yoga training with given id: {id} not exists.");

            response.Data = _mapper.Map<GetYogaTrainingDto>(yogaTraining);

            return response;
        }

        public async Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainingsByUser(int userId)
        {
            var response = new ServiceResponse<List<GetYogaTrainingDto>>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var userYogaTrainings = await _context.YogaTrainings
                .Include(y => y.Location)
                .Where(y => y.Participants.Contains(user!)).ToListAsync();

            response.Data = userYogaTrainings.Select(_mapper.Map<GetYogaTrainingDto>).ToList();

            return response;
        }

        public async Task<ServiceResponse<List<GetYogaTrainingDto>>> GetYogaTrainings()
        {
            var response = new ServiceResponse<List<GetYogaTrainingDto>>();

            var yogaTrainings = await _context.YogaTrainings
                .Include(y => y.Location)
                .ToListAsync();

            response.Data = yogaTrainings.Select(_mapper.Map<GetYogaTrainingDto>).ToList();

            return response;
        }

        public async Task<ServiceResponse<List<GetYogaTrainingDto>>> DeleteYogaTraining(int id)
        {
            var response = new ServiceResponse<List<GetYogaTrainingDto>>();

            var yogaTraining = await _context.YogaTrainings.FirstOrDefaultAsync(u => u.Id == id);

            if (yogaTraining == null)
                throw new NotFoundException("No yoga training with id = {id} was found");

            _context.Remove(yogaTraining);
            await _context.SaveChangesAsync();


            var yogaTrainings = await _context.YogaTrainings
                .ToListAsync();

            response.Data = yogaTrainings.Select(_mapper.Map<GetYogaTrainingDto>).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetYogaTrainingDto>> UpdateYogaTraining(UpdateYogaTrainingDto updateYogaTrainingDto, int id)
        {
            var response = new ServiceResponse<GetYogaTrainingDto>();

            var yogaTraining = await _context.YogaTrainings
                .Include(y => y.Location)
                .FirstOrDefaultAsync(y => y.Id == id);

            if (yogaTraining == null)
                throw new NotFoundException("No yoga training with id = {id} was found");

            _mapper.Map(updateYogaTrainingDto, yogaTraining);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetYogaTrainingDto>(yogaTraining);
            response.Message = "Yoga training has been updated.";

            return response;
        }

        public async Task<ServiceResponse<GetYogaTrainingDto>> AddUserToTraining(int trainingId, int userId)
        {
            var response = new ServiceResponse<GetYogaTrainingDto>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var yogaTraining = await _context.YogaTrainings
                .Include(y => y.Location)
                .Include(y => y.Participants)
                .FirstOrDefaultAsync(y => y.Id == trainingId);

            if (user == null || yogaTraining == null)
                throw new NotFoundException("User or training with given id was not found.");

            if (yogaTraining.Participants.Contains(user))
                throw new Exception("User is already on list");

            if (yogaTraining.MaxParticipants == yogaTraining.CurrentParticipants)
                throw new Exception("Training is full, cant add another user.");


            yogaTraining.Participants.Add(user);
            yogaTraining.CurrentParticipants++;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetYogaTrainingDto>(yogaTraining);
            response.Message = "User added to training.";

            return response;
        }

        public async Task<ServiceResponse<GetYogaTrainingDto>> RemoveUserFromTraining(int trainingId, int userId)
        {
            var response = new ServiceResponse<GetYogaTrainingDto>();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var yogaTraining = await _context.YogaTrainings
                .Include(y => y.Location)
                .Include(y => y.Participants)
                .FirstOrDefaultAsync(y => y.Id == trainingId);

            if (user == null || yogaTraining == null)
                throw new NotFoundException("User or training with given id was not found.");

            if (!yogaTraining.Participants.Contains(user))
                throw new Exception("User is not on the list");

            yogaTraining.Participants.Remove(user);
            yogaTraining.CurrentParticipants--;

            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetYogaTrainingDto>(yogaTraining);
            response.Message = "User removed from the training.";

            return response;
        }
    }
}
