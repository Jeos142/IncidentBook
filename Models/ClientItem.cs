using System.ComponentModel.DataAnnotations;

namespace IncidentBook.Models
{
    public class ClientItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<IncidentItem>? Incidents { get; set; }
    }
}
