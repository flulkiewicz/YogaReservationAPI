
using YogaReservationAPI.Data;
using YogaReservationAPI.Dtos.User;

namespace YogaReservationAPI.Dtos.Validators
{
    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator(DataContext context) 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(25).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("Confirmed Password do not match Password.");


            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(x => x.Email)
                .Custom((value, result) =>
                {
                    var emailUsed = context.Users.Any(x => x.Email == value);

                    if (emailUsed)
                        result.AddFailure("Email", "That email is already taken.");
                });

        }
    }
}
