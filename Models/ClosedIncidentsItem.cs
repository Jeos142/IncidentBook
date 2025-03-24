using System.ComponentModel.DataAnnotations;

namespace IncidentBook.Models
{
    public class ClosedIncidentsItem
    {
        [Key]
        public int Id { get; set; }
        public string? Resolution { get; set; }
        public ICollection<IncidentItem>? Incidents { get; set; }
    }
}
