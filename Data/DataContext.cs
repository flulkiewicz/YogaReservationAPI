using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Models;

namespace YogaReservationAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                    new Location { Id=1,  Address = "To be confirmed" }
                );

            modelBuilder.Entity<YogaClass>()
                .Property(x => x.LocationId)
                .HasDefaultValue(1);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<YogaClass> YogaClasses { get; set; }
        public DbSet<Location> Locations { get; set; }

        

    }
}
