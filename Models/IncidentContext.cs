using Microsoft.EntityFrameworkCore;
namespace IncidentBook.Models
{
    public class IncidentContext: DbContext
    {
        public IncidentContext(DbContextOptions<IncidentContext> options)
       : base(options)
        {
        }

        public DbSet<IncidentItem> TodoItems { get; set; } = null!;
        public DbSet<ClientItem> ClientItems { get; set; } = null!;
        public DbSet<ClosedIncidentsItem> ClosedIncidentsItems { get; set; } = null!;
        public DbSet<IncidentClassification> IncidentClassifications { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<IncidentItem>()
                .HasOne(i => i.Classification)
                .WithMany(c => c.Incidents)
                .HasForeignKey(i => i.ClassificationId)
                
                .OnDelete(DeleteBehavior.Restrict); //  Не удалять инциденты при удалении классификации

            
            modelBuilder.Entity<IncidentItem>()
                .HasOne(i => i.Resolution)
                .WithMany(r => r.Incidents)
                .HasForeignKey(i => i.ResolutionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
