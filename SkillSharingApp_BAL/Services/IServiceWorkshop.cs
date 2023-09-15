using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_BAL.Services
{
    public interface IServiceWorkshop
    {
        void CreateWorkShop(Workshop workshop);
        IEnumerable<Workshop> GetAllWorkshops(string userId);
        Workshop GetWorkShopById(int id);
        void UpdateWorkShop(Workshop lesson);
        void DeleteWorkShopById(int id);
        List<Workshop> WorkShopsByNamePublic(string name, string userId);
        void changeWorkShopAvailability(Workshop workshop);
        void DeleteWorkshopImage(int workshopId, string imageId);
        CreateApplicationUserDto_DAL GetUser(string id);
    }
}
