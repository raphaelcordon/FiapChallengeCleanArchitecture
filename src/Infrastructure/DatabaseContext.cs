using Domain.Entities.Food;
using Domain.Entities.ThirdPartyRegister;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; } = null!;
        public DbSet<Receiver> Receivers { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DonorMapping());
            modelBuilder.ApplyConfiguration(new ReceiverMapping());
            modelBuilder.ApplyConfiguration(new FoodMapping());
        }
    }
}