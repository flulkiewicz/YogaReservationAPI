namespace YogaReservationAPI.Dtos.YogaTraining
{
    public class AddYogaTrainingDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public int MaxParticipants { get; set; }
    }
}
