namespace YogaReservationAPI.Models
{
    public class YogaTraining
    {
        public int Id { get; set; }s
        public DateTime? Date { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public List<User> Participants { get; set; } = new List<User>();
        public int MaxParticipants { get; set; }
    }
}
