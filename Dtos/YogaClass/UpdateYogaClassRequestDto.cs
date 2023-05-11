namespace YogaReservationAPI.Dtos.YogaClass
{
    public class UpdateYogaClassRequestDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
    }
}
