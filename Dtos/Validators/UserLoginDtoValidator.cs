using YogaReservationAPI.Data;
using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Dtos.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator(DataContext context)
        {
            RuleFor(x => x.Email).NotEmpty();

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
