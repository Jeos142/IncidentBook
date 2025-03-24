namespace IncidentBook.Models.DTOs
{
    // Один в один копия IncidentCreateDTO, создан на всякий случай
    public class IncidentUpdateDto
    {
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int ClassificationId { get; set; }
        public bool IsComplete { get; set; }
        public int? ResolutionId { get; set; } 
    }
}
