﻿using Microsoft.AspNetCore.Identity;

namespace YogaReservationAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public List<YogaTraining> YogaTrainings { get; set; } = new List<YogaTraining>();
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
    }
}
