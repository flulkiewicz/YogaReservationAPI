using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace YogaReservationAPI.Data.Configurations
{
    public class YogaTrainingConfiguration : IEntityTypeConfiguration<YogaTraining>
    {
        public void Configure(EntityTypeBuilder<YogaTraining> builder)
        {
            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.MaxParticipants).IsRequired();

            builder.Property(x => x.LocationId).HasDefaultValue(1);

            builder.Property(x => x.CurrentParticipants).HasDefaultValue(0);
        }
    }
}
