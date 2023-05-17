namespace YogaReservationAPI.Dtos.YogaTraining
{
    public class GetYogaTrainingDto
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public User? Instructor { get; set; }
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int MaxParticipants { get; set; }
        public int CurrentPaticipants { get; set; } = 0;
    }
}
