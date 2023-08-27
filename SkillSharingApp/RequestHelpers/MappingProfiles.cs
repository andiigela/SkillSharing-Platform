using AutoMapper;
using SkillSharingApp.Models;
using SkillSharingApp_BAL.DTOs.ApplicationUser;

namespace SkillSharingApp.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateApplicationUserDto_BAL, ApplicationUser>();
        }
    }
}