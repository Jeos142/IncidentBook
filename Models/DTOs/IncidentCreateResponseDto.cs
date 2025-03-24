namespace IncidentBook.Models.DTOs
{
    //Создан для отправки имени клиента, классификации и резолюции на фронт при создании инцидента
    public class IncidentCreateResponseDto
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int ClassificationId { get; set; }
        public string Classification { get; set; }
        public bool IsComplete { get; set; }
        public int? ResolutionId { get; set; }
        public string Resolution { get; set; }
    }
}
