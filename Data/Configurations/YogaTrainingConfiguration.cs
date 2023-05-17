using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        }
    }
}
