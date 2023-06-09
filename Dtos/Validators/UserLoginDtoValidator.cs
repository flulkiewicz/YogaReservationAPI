﻿using YogaReservationAPI.Data;
using YogaReservationAPI.Dtos.UserDtos;

namespace YogaReservationAPI.Dtos.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty();

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
