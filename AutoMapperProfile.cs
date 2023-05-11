using AutoMapper;
using YogaReservationAPI.Dtos.YogaClass;

namespace YogaReservationAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<YogaClass, GetYogaClassResponseDto>();
            CreateMap<AddYogaClassRequestDto, YogaClass>();
            CreateMap<UpdateYogaClassRequestDto, YogaClass>();
        }
    }
}
