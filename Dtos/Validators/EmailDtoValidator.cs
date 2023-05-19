using YogaReservationAPI.Dtos.NotificationsDtos;

namespace YogaReservationAPI.Dtos.Validators
{
    public class EmailDtoValidator : AbstractValidator<EmailDto>
    {
        public EmailDtoValidator()
        {
            RuleFor(x => x.Subject).MinimumLength(4);

            RuleFor(x => x.Body).NotEmpty();
        }
    }
}
