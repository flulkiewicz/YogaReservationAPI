using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Data.Auth;
using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Controllers
{
    [ApiController]
    [Route("/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _authRepository.Register(userRegisterDto);
                    
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto userLoginDto)
        {
            var response = await _authRepository.Login(userLoginDto.Email, userLoginDto.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
