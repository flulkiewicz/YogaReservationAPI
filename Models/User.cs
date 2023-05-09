using Microsoft.AspNetCore.Identity;

namespace YogaReservationAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public bool InstructorStatus { get; set; } = false;
        public List<YogaClass> YogaClasses { get; set; } = new List<YogaClass>();
    }
}
