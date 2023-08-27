using AutoMapper;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_BAL.DTOs.ApplicationUser;

namespace SkillSharingApp_BAL.BAL_RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateApplicationUserDto_DAL, CreateApplicationUserDto_BAL>();
        }
    }
}
