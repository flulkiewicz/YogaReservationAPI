namespace YogaReservationAPI.Dtos.YogaClass
{
    public class AddYogaClassRequestDto
    {
        public string Description { get; set; } = "Template description";
        public string Instructor { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
