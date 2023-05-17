using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Data;
using YogaReservationAPI.Dtos.UserDtos;
using YogaReservationAPI.Exceptions;

namespace YogaReservationAPI.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetUserFullInfoDto>> GetUserFullInfoById(int id)
        {
            var response = new ServiceResponse<GetUserFullInfoDto>();

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new NotFoundException("User not found.");

            response.Data = _mapper.Map<GetUserFullInfoDto>(user);

            return response;
        }
    }
}
