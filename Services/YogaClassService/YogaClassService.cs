using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Data;

namespace YogaReservationAPI.Services.YogaClass
{
    public class YogaClassService : IYogaClassService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public YogaClassService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetYogaClassResponseDto>> AddYogaClass(AddYogaClassRequestDto addYogaClassRequestDto)
        {
            var serviceResponse = new ServiceResponse<GetYogaClassResponseDto>();

            var newYogaClass = _mapper.Map<Models.YogaClass>(addYogaClassRequestDto);

            newYogaClass.Location = _context.Locations.FirstOrDefault(x => x.Id == addYogaClassRequestDto.LocationId);

            _context.YogaClasses.Add(newYogaClass);

            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetYogaClassResponseDto>(newYogaClass);
            serviceResponse.Message = "Yoga class has been added.";

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetYogaClassResponseDto>>> DeleteYogaClass(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetYogaClassResponseDto>>();

            var yogaClass = await _context.YogaClasses.FirstOrDefaultAsync(x => x.Id == id);
            if (yogaClass == null)
                throw new Exception($"Yoga class with given id {id} not found.");

            _context.YogaClasses.Remove(yogaClass);

            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.YogaClasses
                .Select(y => _mapper.Map<GetYogaClassResponseDto>(y))
                .ToListAsync();
            serviceResponse.Message = "Yoga class was successfully deleted.";

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetYogaClassResponseDto>>> GetAllYogaClasses()
        {
            var serviceResponse = new ServiceResponse<List<GetYogaClassResponseDto>>();

            var yogaClasses = await _context.YogaClasses
                .Include(y => y.Location)
                .ToListAsync();

            serviceResponse.Data = yogaClasses.Select(c => _mapper.Map<GetYogaClassResponseDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetYogaClassResponseDto>> GetYogaClassById(int id)
        {
            var serviceResponse = new ServiceResponse<GetYogaClassResponseDto>();

            var yogaClass = await _context.YogaClasses
                .FirstOrDefaultAsync(c => c.Id == id);

            serviceResponse.Data = _mapper.Map<GetYogaClassResponseDto>(yogaClass);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetYogaClassResponseDto>> UpdateYogaClass(UpdateYogaClassRequestDto updateYogaClassRequestDto)
        {
            var serviceResponse = new ServiceResponse<GetYogaClassResponseDto>();

            var yogaClass = await _context.YogaClasses.FirstOrDefaultAsync(y => y.Id == updateYogaClassRequestDto.Id);

            if (yogaClass == null)
                throw new Exception($"Yoga class with given id: {updateYogaClassRequestDto.Id} not exists.");

            _mapper.Map(updateYogaClassRequestDto, yogaClass);

            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetYogaClassResponseDto>(yogaClass);
            serviceResponse.Message = "Class has been updated!";

            return serviceResponse;
        }
    }
}
