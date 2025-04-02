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
    public static class IncidentContextInitializer
    {
        public static async Task InitializeAsync(IncidentContext context)
        {
            
            await context.Database.MigrateAsync();

            // Добавляем клиентов, если их нет
            if (!context.ClientItems.Any())
            {
                context.ClientItems.AddRange(
                    new ClientItem { Name = "Василий" },
                    new ClientItem { Name = "Екатерина" },
                    new ClientItem { Name = "Алексей" }
                );
            }

            // Добавляем классификации, если их нет
            if (!context.IncidentClassifications.Any())
            {
                context.IncidentClassifications.AddRange(
                    new IncidentClassification { ClassificationName = "Сбой ПО" },
                    new IncidentClassification { ClassificationName = "Проблема с оборудованием" },
                    new IncidentClassification { ClassificationName = "Ошибка сети" }
                );
            }

            // Добавляем резолюции, если их нет
            if (!context.ClosedIncidentsItems.Any())
            {
                context.ClosedIncidentsItems.AddRange(
                    new ClosedIncidentsItem { Resolution = "Закрыто ТП 1-го уровня" },
                    new ClosedIncidentsItem { Resolution = "Закрыто ТП 2-го уровня" },
                    new ClosedIncidentsItem { Resolution = "Закрыто ТП 3-го уровня" },
                    new ClosedIncidentsItem { Resolution = "Другое" }
                );
            }

            await context.SaveChangesAsync();
        }
    }

}
