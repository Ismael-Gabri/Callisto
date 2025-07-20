using Microsoft.EntityFrameworkCore;
using Callisto.Domain.Entities;
using Callisto.Domain.Value_Objects;

namespace Callisto.Domain.Infra.Contexts
{
    public class CallistoContext : DbContext
    {
        public CallistoContext(DbContextOptions<CallistoContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.OwnsOne(u => u.Email);
                entity.OwnsOne(u => u.Name);
                entity.OwnsOne(u => u.Phone);

                entity.Ignore(u => u.Notifications);

                // Se não tiver relacionamento Tickets, pode remover essa parte:
                // entity.HasMany(u => u.Tickets)
                //       .WithOne(t => t.Creator)
                //       .HasForeignKey(t => t.CreatorId)
                //       .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(t => t.Company)
                      .WithMany()  // ou .WithMany(c => c.Tickets) se existir coleção em Company
                      .HasForeignKey(t => t.CompanyId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Team)
                      .WithMany()  // ou .WithMany(t => t.Tickets) se existir coleção em Team
                      .HasForeignKey(t => t.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Outras configurações para Team e Company se quiser
        }
    }
}
