using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace YogaReservationAPI.Data.Configurations
{
    public class YogaClassConfiguration : IEntityTypeConfiguration<YogaClass>
    {
        public void Configure(EntityTypeBuilder<YogaClass> builder)
        {
            builder.Property(x => x.LocationId)
                   .HasDefaultValue(1);
        }
    }
}
