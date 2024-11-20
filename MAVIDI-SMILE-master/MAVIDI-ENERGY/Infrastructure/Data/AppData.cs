using MAVIDI_ENERGY.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAVIDI_ENERGY.Infrastructure.Data
{
    public class AppData : DbContext
    {
        public AppData(DbContextOptions<AppData> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<EnergyUsage> EnergyUsages { get; set; }
        public DbSet<SolarProvider> SolarProviders { get; set; }
        public DbSet<EducationalContent> EducationalContents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EnergyUsage>()
                .HasOne(eu => eu.User)
                .WithMany()
                .HasForeignKey(eu => eu.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}