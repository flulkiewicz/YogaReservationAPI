using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Data.Auth;
using YogaReservationAPI.Dtos.User;

namespace YogaReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto userRegisterDto)
        {
            var response = await _authRepository.Register(userRegisterDto);
                    
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
