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
            base.OnModelCreating(modelBuilder);

            // Клиенты
            modelBuilder.Entity<ClientItem>().HasData(
                new ClientItem { Id = 1, Name = "Василий" },
                new ClientItem { Id = 2, Name = "Екатерина" },
                new ClientItem { Id = 3, Name = "Алексей" }
            );

            // Классификации
            modelBuilder.Entity<IncidentClassification>().HasData(
                new IncidentClassification { Id = 1, ClassificationName = "Сбой ПО" },
                new IncidentClassification { Id = 2, ClassificationName = "Ошибка сети" }
            );

            // Резолюции
            modelBuilder.Entity<ClosedIncidentsItem>().HasData(
                new ClosedIncidentsItem { Id = 1, Resolution = "Закрыто ТП 1-го уровня" },
                new ClosedIncidentsItem { Id = 2, Resolution = "Закрыто ТП 2-го уровня" },
                new ClosedIncidentsItem { Id = 3, Resolution = "Закрыто ТП 3-го уровня" },
                new ClosedIncidentsItem { Id = 4, Resolution = "Другое" }
            );
        }

    }

    

}
