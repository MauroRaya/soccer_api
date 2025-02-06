﻿namespace soccer_api.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AmountGoals { get; set; }
        public int TeamId { get; set; }
    }
}