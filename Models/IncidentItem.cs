﻿namespace IncidentBook.Models
{
    public class IncidentItem
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        public string? Classification { get; set; }
        public int Client { get; set; } 
        public bool IsComplete { get; set; }
        public string? Resolution { get; set; }
    }
}
