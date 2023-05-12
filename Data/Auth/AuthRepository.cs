using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YogaReservationAPI.Dtos.User;

namespace YogaReservationAPI.Data.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
        

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower()))
            {
                return true;
            }

            return false;
        }
        public async Task<ServiceResponse<int>> Register(UserRegisterDto userRegisterDto)
        {
            var response = new ServiceResponse<int>();

            CreatePasswordHash(userRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<User>(userRegisterDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;

            return response;
        }
        public Task<ServiceResponse<string>> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
