namespace YogaReservationAPI.Dtos.YogaTraining
{
    public class GetYogaTrainingDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int MaxParticipants { get; set; }
        public int CurrentParticipants { get; set; }
    }
}
