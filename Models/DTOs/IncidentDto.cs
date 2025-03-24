namespace IncidentBook.Models.DTOs
{
    //Копия модели инцидента (IncidentItem)
    public class IncidentDto
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }     
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        public int ClassificationId { get; set; }
        public ClassificationDto Classification { get; set; }
        public bool IsComplete { get; set; }
        public int? ResolutionId { get; set; }
        public ResolutionDto? Resolution { get; set; }
    }
}
