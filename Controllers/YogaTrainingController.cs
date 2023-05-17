using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Dtos.YogaTraining;
using YogaReservationAPI.Services.YogaTrainingService;

namespace YogaReservationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YogaTrainingController : ControllerBase
    {
        private readonly IYogaTrainingService _yogaTrainingService;

        public YogaTrainingController(IYogaTrainingService yogaTrainingService)
        {
            _yogaTrainingService = yogaTrainingService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetYogaTrainingDto>>> GetYogaTrainingById(int id)
        {
            return Ok(await _yogaTrainingService.GetYogaTrainignById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetYogaTrainingDto>>> AddYogaTraining(AddYogaTrainingDto addYogaTrainingDto)
        {
            return Ok(await _yogaTrainingService.AddYogaTraining(addYogaTrainingDto));
        }
    }
}
