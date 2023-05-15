namespace YogaReservationAPI.Dtos.YogaClass
{
    public class GetYogaClassResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public Location? Location { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public List<Models.User> Users { get; set; } = new List<Models.User>();
    }
}
