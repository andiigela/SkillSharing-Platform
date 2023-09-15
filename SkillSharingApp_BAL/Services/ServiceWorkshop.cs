using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_BAL.Services
{
    public class ServiceWorkshop : IServiceWorkshop
    {
        private readonly IWorkshopRepository<Workshop> workshopRepository;
        public ServiceWorkshop(IWorkshopRepository<Workshop> workshopRepository)
        {
            this.workshopRepository = workshopRepository;
        }
        public void CreateWorkShop(Workshop workshop)
        {
            if (workshop == null) return;
            workshopRepository.Create(workshop);
        }
        public IEnumerable<Workshop> GetAllWorkshops(string userId)
        {
            return workshopRepository.GetAll(userId);
        }
        public void DeleteWorkShopById(int id)
        {
            if (id == 0 || id == null) return;
            workshopRepository.DeleteById(id);
        }
        public Workshop GetWorkShopById(int id)
        {
            if (id == 0 || id == null) return null;
            return workshopRepository.GetById(id);
        }
        public void UpdateWorkShop(Workshop workshop)
        {
            if (workshop == null) return;
            workshopRepository.Update(workshop);
        }
        public List<Workshop> WorkShopsByNamePublic(string name, string userId)
        {
            if (name == null || name.Equals("")) return null;
            return workshopRepository.WorkShopsByNamePublic(name, userId);
        }
        public void changeWorkShopAvailability(Workshop workshop)
        {
            if (workshop == null) return;
            workshopRepository.changeWorkShopAvailability(workshop);
        }
        public void DeleteWorkshopImage(int workshopId, string imageId)
        {
            if (workshopId == 0 || workshopId == null) return;
            if (imageId.Equals("") || workshopId == null) return;
            workshopRepository.DeleteImage(workshopId, imageId);
        }
        public CreateApplicationUserDto_DAL GetUser(string id)
        {
            if (id.Equals("") || id == null) return null;
            return workshopRepository.GetUser(id);
        }
    }
}
