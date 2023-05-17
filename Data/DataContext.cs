using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Models;

namespace YogaReservationAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<YogaTraining> YogaTrainings { get; set; }
    }
}
