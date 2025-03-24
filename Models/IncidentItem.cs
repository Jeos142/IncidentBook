using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentBook.Models
{
    public class IncidentItem
    {
        [Key]
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Classification")]
        public int ClassificationId { get; set; }

        
        public IncidentClassification Classification { get; set; }

        [ForeignKey("ClientItem")]
        public int ClientId { get; set; }
        public ClientItem? ClientItem { get; set; }
        public bool IsComplete { get; set; }
        [ForeignKey("Resolution")]
        public int? ResolutionId { get; set; }
        public ClosedIncidentsItem? Resolution { get; set; }
    }
}
