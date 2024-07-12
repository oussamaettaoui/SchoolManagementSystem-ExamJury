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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JuryMember>(jm =>
            {
                jm.HasKey(x => x.Id);
            });
            modelBuilder.Entity<Meeting>(m =>
            {
                m.HasKey(meeting => meeting.Id);

                m.HasOne(meeting => meeting.Jury)
                    .WithOne(jury => jury.Meeting)
                    .HasForeignKey<Meeting>(meeting => meeting.JuryId);
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
                        SectorId = 1,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    },
                    new Jury
                    {
                        Id = Guid.NewGuid(),
                        JuryName = "TIC Jury",
                        SectorId = 2,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    }
                );
            });
        }
    }
}
