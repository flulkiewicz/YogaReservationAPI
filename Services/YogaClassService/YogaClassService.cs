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

        public async Task<ServiceResponse<List<GetYogaClassResponseDto>>> GetAllYogaClasses()
        {
            var serviceResponse = new ServiceResponse<List<GetYogaClassResponseDto>>();

            var yogaClasses = await _context.YogaClasses.ToListAsync();

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
    }
}
