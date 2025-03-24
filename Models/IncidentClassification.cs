using System.ComponentModel.DataAnnotations;

namespace IncidentBook.Models
{
    public class IncidentClassification
    {
        [Key]
        public int Id { get; set; }
        public string? ClassificationName { get; set; }
        public ICollection<IncidentItem>? Incidents { get; set; }
    }
}
