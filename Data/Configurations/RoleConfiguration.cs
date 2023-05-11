using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace YogaReservationAPI.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(
                new Role() { Id=1, Name="User"},
                new Role() { Id=2, Name="Instructor"},
                new Role() { Id=3, Name="Administrator"}
                );
        }
    }
}
