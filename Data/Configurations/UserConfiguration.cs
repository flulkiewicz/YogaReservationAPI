using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace YogaReservationAPI.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(x => x.Surname)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(x => x.Email)
                   .IsRequired();

            builder.Property(x => x.RoleId)
                   .HasDefaultValue(1);
        }
    }
}
