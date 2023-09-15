namespace SkillSharingApp_DAL.Contracts
{
    public interface IApplicationUserRepository<CreateApplicationUserDto_DAL>
    {
        void Create(CreateApplicationUserDto_DAL applicationUser);
        CreateApplicationUserDto_DAL GetById(string id);
    }
}
