using System.Linq;
using AutoMapper;
using DatingApp.Dtos;
using DatingApp.Models;

namespace DatingApp.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDto>()
                    .ForMember(dest => dest.PhotosUrl, opt => {
                        opt.MapFrom(src => src.Photos.FirstOrDefault( p => p.IsMain).Url);
                    })
                    .ForMember(dest => dest.Age, opt => {
                        opt.ResolveUsing( d => d.DateOfBirth.CalculateAge());
                    });
            CreateMap<User, UserForDetailesDto>()
                    .ForMember(dest => dest.PhotosUrl, opt => {
                        opt.MapFrom(src => src.Photos.FirstOrDefault( p => p.IsMain).Url);
                    })
                    .ForMember(dest => dest.Age, opt => {
                        opt.ResolveUsing( d => d.DateOfBirth.CalculateAge());
                    });
            CreateMap<Photo, PhotosDetailsDto>();
            CreateMap<UserUpdatenDto, User>();
        }
    }
}