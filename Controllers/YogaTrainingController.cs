using Microsoft.AspNetCore.Mvc;
using YogaReservationAPI.Dtos.YogaTraining;
using YogaReservationAPI.Services.YogaTrainingService;

namespace YogaReservationAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/training")]
    public class YogaTrainingController : ControllerBase
    {
        private readonly IYogaTrainingService _yogaTrainingService;

        public YogaTrainingController(IYogaTrainingService yogaTrainingService)
        {
            _yogaTrainingService = yogaTrainingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<List<GetYogaTrainingDto>>>> GetAll()
        {
            return Ok(await _yogaTrainingService.GetYogaTrainings());
        }



        [HttpGet("/{id}")]
        public async Task<ActionResult<ServiceResponse<GetYogaTrainingDto>>> GetYogaTrainingById(int id)
        {
            return Ok(await _yogaTrainingService.GetYogaTrainignById(id));
        }

        [HttpGet("/my-trainings")]
        public async Task<ActionResult<ServiceResponse<List<GetYogaTrainingDto>>>> GetYogaTrainingByUser()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

            return Ok(await _yogaTrainingService.GetYogaTrainingsByUser(userId));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetYogaTrainingDto>>> AddYogaTraining(AddYogaTrainingDto addYogaTrainingDto)
        {
            return Ok(await _yogaTrainingService.AddYogaTraining(addYogaTrainingDto));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetYogaTrainingDto>>>> DeleteYogaTraining(int id)
        {
            return Ok(await _yogaTrainingService.DeleteYogaTraining(id));
        }

        [HttpPatch]
        public async Task<ActionResult<ServiceResponse<GetYogaTrainingDto>>> UpdateYogaTraining(UpdateYogaTrainingDto updateYogaTrainingDto, int id)
        {
            return Ok(await _yogaTrainingService.UpdateYogaTraining(updateYogaTrainingDto, id));
        }

        [HttpPatch("/add-participant")]
        public async Task<ActionResult<ServiceResponse<List<GetYogaTrainingDto>>>> AddUserToTraining(int trainingId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

            return Ok(await _yogaTrainingService.AddUserToTraining(trainingId, userId));
        }

        [HttpPatch("/remove-participant")]
        public async Task<ActionResult<ServiceResponse<List<GetYogaTrainingDto>>>> RemoveUserFromTraining(int trainingId)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);

            return Ok(await _yogaTrainingService.RemoveUserFromTraining(trainingId, userId));
        }

    }
}
