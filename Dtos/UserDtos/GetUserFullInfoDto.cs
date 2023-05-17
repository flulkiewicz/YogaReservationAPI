namespace YogaReservationAPI.Dtos.UserDtos
{
    public class GetUserFullInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }
        public bool InstructorStatus { get; set; } = false;
    }
}
