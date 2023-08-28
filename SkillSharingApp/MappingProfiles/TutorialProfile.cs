using AutoMapper;
using SkillSharingApp_BAL.DTOs;
using SkillSharingApp_DAL.Models;


namespace SkillSharingApp_BAL.MappingProfiles
{
    public class TutorialProfile : Profile
    {
        public TutorialProfile()
        {
            CreateMap<Tutorial, TutorialDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TutorialId))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
                .ForMember(dest => dest.Instructions, opt => opt.MapFrom(src => src.Instructions))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(src => src.VideoUrl))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.ToList()))
                .ReverseMap();
        }
    }
}
