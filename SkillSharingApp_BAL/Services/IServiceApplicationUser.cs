using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;

namespace SkillSharingApp_BAL.Services
{
    public interface IServiceApplicationUser
    {
        void CreateApplicationUser(CreateApplicationUserDto_DAL applicationUser);
        CreateApplicationUserDto_DAL getApplicationUserById(string id);
    }
}
