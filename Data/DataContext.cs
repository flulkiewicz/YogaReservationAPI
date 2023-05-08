using Microsoft.EntityFrameworkCore;
using YogaReservationAPI.Models;

namespace YogaReservationAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<YogaClass> YogaClasses { get; set; }

    }
}
