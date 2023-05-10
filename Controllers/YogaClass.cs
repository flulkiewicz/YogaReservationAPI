using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Services.YogaClass;

namespace YogaReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YogaClass : ControllerBase
    {
        private readonly IYogaClassService _yogaClassService;

        public YogaClass(IYogaClassService yogaClassService)
        {
            _yogaClassService = yogaClassService;
        }

        [HttpGet] 
        public async Task<ActionResult<ServiceResponse<GetYogaClassResponseDto>>> GetYogaClass(int id)
        {
            return Ok(await _yogaClassService.GetYogaClassById(id));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetYogaClassResponseDto>>>> GetYogaClasses()
        {
            return Ok(await _yogaClassService.GetAllYogaClasses()); 
        }
    }
}
