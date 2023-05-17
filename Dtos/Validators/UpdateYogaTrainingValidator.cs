using YogaReservationAPI.Dtos.YogaTraining;

namespace YogaReservationAPI.Dtos.Validators
{
    public class UpdateYogaTrainingValidator : AbstractValidator<UpdateYogaTrainingDto>
    {
        public UpdateYogaTrainingValidator()
        {
            RuleFor(x => x.Description).MinimumLength(5);

            RuleFor(x => x.MaxParticipants).GreaterThan(0);

            RuleFor(x => x.Date)
                .Custom((value, result) =>
                {
                    var now = DateTime.UtcNow;

                    if (value <= now)
                        result.AddFailure("Date", "Date cannot be in past for new training.");
                });
        }
    }
}
