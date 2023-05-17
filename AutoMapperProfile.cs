using AutoMapper;
using YogaReservationAPI.Dtos.UserDtos;
using YogaReservationAPI.Dtos.YogaTraining;

namespace YogaReservationAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, GetUserFullInfoDto>();
            CreateMap<AddYogaTrainingDto, YogaTraining>();
            CreateMap<YogaTraining, GetYogaTrainingDto>();
            CreateMap<UpdateYogaTrainingDto, YogaTraining>();
        }
    }
}
