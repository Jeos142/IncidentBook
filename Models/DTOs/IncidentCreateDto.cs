namespace IncidentBook.Models.DTOs
{
    public class IncidentCreateDto
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int ClassificationId { get; set; }
        public bool IsComplete { get; set; }
        public int? ResolutionId { get; set; } 
    }
}
