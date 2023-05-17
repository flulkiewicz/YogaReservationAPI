namespace YogaReservationAPI.Dtos.YogaTraining
{
    public class AddYogaTrainingDto
    {
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public int MaxParticipants { get; set; }
    }
}
