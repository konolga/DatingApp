using System.Linq;
using AutoMapper;
using webAPI.Controllers;
using webAPI.Dtos;
using webAPI.Models;

namespace webAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom (src => src.Photos.FirstOrDefault (p=> p.IsMain).Url);
                });


            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                opt.MapFrom (src => src.Photos.FirstOrDefault (p=> p.IsMain).Url);
                });


            CreateMap<Photo, PhotoForDetailedDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();

        }
    }
}