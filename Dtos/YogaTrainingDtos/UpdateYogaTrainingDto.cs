namespace YogaReservationAPI.Dtos.YogaTraining
{
    public class UpdateYogaTrainingDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public int LocationId { get; set; } = 1;
        public int MaxParticipants { get; set; }
    }
}
