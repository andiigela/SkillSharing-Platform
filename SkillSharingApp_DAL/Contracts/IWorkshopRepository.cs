using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;

namespace SkillSharingApp_DAL.Contracts
{
    public interface IWorkshopRepository<Workshop>
    {
        void Create(Workshop workshop);
        IEnumerable<Workshop> GetAll(string userId);
        Workshop GetById(int id);
        void Update(Workshop workshop);
        void DeleteById(int id);
        List<Workshop> WorkShopsByNamePublic(string name, string userId);
        void changeWorkShopAvailability(Workshop workshop);
        void DeleteImage(int workshopId, string imageId);
        CreateApplicationUserDto_DAL GetUser(string id);
    }
}
