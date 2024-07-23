using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Jury> Juries { get; set; }
        public DbSet<JuryMember> JuryMembers { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<JuryMemberRole> JuryMemberRoles { get; set; }
        public DbSet<DayOrder> dayOrders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JuryMemberRole>(r =>
            {
                r.HasKey(x => x.Id);
                r.HasData(
                    new JuryMemberRole
                    {
                        Id = Guid.NewGuid(),
                        Role = "Président"
                    },
                    new JuryMemberRole
                    {
                        Id = Guid.NewGuid(),
                        Role = "Membre Professionnel"
                    },
                    new JuryMemberRole
                    {
                        Id = Guid.NewGuid(),
                        Role = "Membre de l’établissement"
                    },
                    new JuryMemberRole
                    {
                        Id = Guid.NewGuid(),
                        Role = "Membre représentant l’Administration"
                    }
                );
            });
            modelBuilder.Entity<JuryMember>(jm =>
            {
                jm.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Meeting>(m =>
            {
                m.HasKey(m => m.Id);
                m.HasMany(u => u.DayOrderModels)
                    .WithOne(u => u.Meeting)
                    .HasForeignKey(u => u.IdMetting);
            });
            modelBuilder.Entity<Jury>(j => {
                j.HasKey(x=>x.Id);
                j.HasMany(x=>x.JuryMembers)
                    .WithOne(jm=>jm.Jury)
                    .HasForeignKey(jm=>jm.JuryId);
                j.HasData(
                    new Jury
                    {
                        Id = Guid.NewGuid(),
                        JuryName = "AGC Jury",
                        SectorId = Guid.Parse("216a893d-740b-47bd-a689-065170b33437"),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Jury
                    {
                        Id = Guid.NewGuid(),
                        JuryName = "TIC Jury",
                        SectorId = Guid.Parse("0caff05b-d501-426f-948d-a841be4a1a3c"),
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                );
            });
        }
    }
}
