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
                //Tabela
                entity.ToTable("User");

                //Key
                entity.HasKey(e => e.Id);

                //FKs
                entity.HasOne<Company>()
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Team>()
                .WithMany()
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany<Ticket>()
                .WithOne(t => t.User) 
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                //VOs
                entity.OwnsOne(u => u.Name, name =>
                {
                    name.Property(n => n.FirstName)
                    .HasColumnName("FirstName")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                    name.Property(n => n.LastName)
                    .HasColumnName("LastName")
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                });

                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Address)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(150)")
                    .IsRequired();
                });

                entity.OwnsOne(u => u.Phone, phone =>
                {
                    phone.Property(p => p.CellPhone)
                    .HasColumnName("Phone")
                    .HasColumnType("varchar(20)")
                    .IsRequired();
                });

                //Simple Coluns
                entity.Property(u => u.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("varchar(255)")
                .IsRequired();

                entity.Property(u => u.ProfileImage)
                .HasColumnName("ProfileImage")
                .HasColumnType("varchar(255)");

                entity.Property(u => u.Role)
                .HasColumnName("Role")
                .HasConversion<int>()
                .IsRequired();

                entity.Property(u => u.EntryDate)
                .HasColumnName("EntryDate")
                .HasColumnType("datetime2");

                entity.Property(u => u.UpdateDate)
                .HasColumnName("UpdateDate")
                .HasColumnType("datetime2");

                entity.Property(u => u.LastLogin)
                .HasColumnName("LastLogin")
                .HasColumnType("datetime2");

                entity.Ignore(u => u.Notifications);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                //Table
                entity.ToTable("Team");

                //Key
                entity.HasKey(t => t.Id);


                entity.Property(t => t.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(150)")
                .IsRequired();

                entity.Property(t => t.IsActive)
                .HasDefaultValue(true);

                entity.Property(t => t.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();

                entity.HasMany(t => t.Users)
                .WithOne(u => u.Team)
                .HasForeignKey(u => u.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(150)")
                    .IsRequired();

                entity.Property(c => c.Cnpj)
                    .HasColumnName("Cnpj")
                    .HasColumnType("varchar(20)")
                    .IsRequired();

                entity.Property(c => c.Email)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(150)")
                    .IsRequired();

                entity.Property(c => c.Phone)
                    .HasColumnName("Phone")
                    .HasColumnType("varchar(20)")
                    .IsRequired();

                entity.Property(c => c.Address)
                    .HasColumnName("Address")
                    .HasColumnType("varchar(255)")
                    .IsRequired();

                entity.Property(c => c.CreatedAt)
                    .HasColumnName("CreatedAt")
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");

                // Chave primária
                entity.HasKey(t => t.Id);

                // FKs
                entity.Property(t => t.CompanyId)
                    .HasColumnName("CompanyId")
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(t => t.TeamId)
                    .HasColumnName("TeamId")
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(t => t.UserId)
                    .HasColumnName("UserId")
                    .HasColumnType("int")
                    .IsRequired();

                entity.HasOne(t => t.Company)
                    .WithMany()
                    .HasForeignKey(t => t.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Team)
                    .WithMany()
                    .HasForeignKey(t => t.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.User)
                    .WithMany()
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Propriedades simples
                entity.Property(t => t.Title)
                    .HasColumnName("Title")
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                entity.Property(t => t.Description)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(max)")
                    .IsRequired();

                entity.Property(t => t.Priority)
                    .HasColumnName("Priority")
                    .HasConversion<int>()
                    .IsRequired();

                entity.Property(t => t.Status)
                    .HasColumnName("Status")
                    .HasConversion<int>()
                    .IsRequired();

                entity.Property(t => t.CreationDate)
                    .HasColumnName("CreationDate")
                    .HasColumnType("datetime2")
                    .IsRequired();

                entity.Property(t => t.UpdateDate)
                    .HasColumnName("UpdateDate")
                    .HasColumnType("datetime2");

                entity.Property(t => t.ResolutionDate)
                    .HasColumnName("ResolutionDate")
                    .HasColumnType("datetime2");
            });
        }
    }
}
