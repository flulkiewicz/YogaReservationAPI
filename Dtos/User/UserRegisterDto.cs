﻿using System.ComponentModel.DataAnnotations;

namespace YogaReservationAPI.Dtos.User
{
    public class UserRegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int RoleId { get; set; } = 1; 
    }
}
