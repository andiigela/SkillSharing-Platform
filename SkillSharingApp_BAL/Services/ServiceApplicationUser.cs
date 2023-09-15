using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;

namespace SkillSharingApp_BAL.Services
{
    public class ServiceApplicationUser : IServiceApplicationUser
    {
        private readonly IApplicationUserRepository<CreateApplicationUserDto_DAL> _applicationUserRepository;
        public ServiceApplicationUser(IApplicationUserRepository<CreateApplicationUserDto_DAL> applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        public void CreateApplicationUser(CreateApplicationUserDto_DAL applicationUser)
        {
            if (applicationUser == null) return;
            _applicationUserRepository.Create(applicationUser);
        }
        public CreateApplicationUserDto_DAL getApplicationUserById(string id)
        {
            if (id.Equals("") || id == null) return null;
            return _applicationUserRepository.GetById(id);
        }
    }
}
