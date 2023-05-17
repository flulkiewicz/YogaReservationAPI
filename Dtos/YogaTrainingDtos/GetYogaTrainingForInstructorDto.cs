namespace YogaReservationAPI.Dtos.YogaTraining
{
    public class GetYogaTrainingForInstructorDto : GetYogaTrainingDto
    {
        public List<User> Participants { get; set; } = new List<User>();
    }
}
