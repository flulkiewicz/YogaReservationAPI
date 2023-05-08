﻿namespace YogaReservationAPI.Models
{
    public class YogaClass
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
