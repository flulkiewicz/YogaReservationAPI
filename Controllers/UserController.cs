using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Dtos.UserDtos;
using YogaReservationAPI.Services.UserService;

namespace YogaReservationAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetUserFullInfoDto>>> GetUserFullInfoById(int id)
        {
            return Ok(await _userService.GetUserFullInfoById(id));
        }
    }
}
