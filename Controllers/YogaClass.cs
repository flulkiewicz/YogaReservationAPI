using Microsoft.AspNetCore.Mvc;
using NLog.Targets.Wrappers;
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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetYogaClassResponseDto>>> AddYogaClass(AddYogaClassRequestDto addYogaClassRequestDto)
        {
            return Ok(await _yogaClassService.AddYogaClass(addYogaClassRequestDto));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetYogaClassResponseDto>>> UpdateYogaClass(UpdateYogaClassRequestDto updateYogaClassRequestDto)
        {
            return Ok(await _yogaClassService.UpdateYogaClass(updateYogaClassRequestDto));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetYogaClassResponseDto>>>> DeleteYogaClasses(int id)
        {
            return Ok(await _yogaClassService.DeleteYogaClass(id));
        }
    }
}
