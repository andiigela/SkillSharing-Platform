using Microsoft.EntityFrameworkCore;
using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Data;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_DAL.Repositories
{
    public class WorkshopRepository : IWorkshopRepository<Workshop>
    {
        private readonly AppDbContext _context;
        private readonly IServiceUploadImage _upload;
        private readonly IApplicationUserRepository<CreateApplicationUserDto_DAL> _applicationUserRepository;
        public WorkshopRepository(AppDbContext _context, IServiceUploadImage _upload, IApplicationUserRepository<CreateApplicationUserDto_DAL> applicationUserRepository)
        {
            this._context = _context;
            this._upload = _upload;
            _applicationUserRepository = applicationUserRepository;

        }
        public void Create(Workshop workshop)
        {
            workshop.AddImageToWorkshop(_upload);
            _context.Workshops.Add(workshop);
            _context.SaveChanges();
        }
        public IEnumerable<Workshop> GetAll(string userId)
        {
            return _context.Workshops.Include(w => w.CreateApplicationUserDto_DAL)
                .Where(w => w.CreateApplicationUserDto_DALId == userId)
                .ToList();
        }
        public void DeleteById(int id)
        {
            var workShopDb = GetById(id);
            workShopDb.Images.ForEach(i => _upload.DeleteImage(i.Path));
            _context.Workshops.Remove(workShopDb);
            _context.SaveChanges();
        }
        public Workshop GetById(int id)
        {
            return _context.Workshops
                    .Include(w => w.Images)
                    .Include(w => w.CreateApplicationUserDto_DAL)
                    .FirstOrDefault(w => w.Id == id);
        }
        public void Update(Workshop workshop)
        {
            _context.Attach(workshop);


            workshop.AddImageToWorkshop(_upload);
            _context.Workshops.Update(workshop);
            _context.SaveChanges();
        }
        public List<Workshop> WorkShopsByNamePublic(string name, string userId)
        {
            return _context.Workshops
                .Include(w => w.Attendances)
                .Where(w => w.CreateApplicationUserDto_DALId != userId)
                .Where(w => w.Title.Contains(name) && w.isVisible == 1)
                .ToList();
        }
        public void DeleteImage(int workshopId, string imageId)
        {
            var workshop = GetById(workshopId);
            var image = workshop.Images.FirstOrDefault(w => w.Id == imageId);
            workshop.Images.Remove(image);
            _upload.DeleteImage(image.Path);
            _context.SaveChanges();
        }
        public void changeWorkShopAvailability(Workshop workshop)
        {
            var workshopDb = _context.Workshops.Find(workshop.Id);
            workshopDb.isVisible = 0;
            _context.Update(workshopDb);
            _context.SaveChanges();
        }
        public CreateApplicationUserDto_DAL GetUser(string id)
        {
            return _applicationUserRepository.GetById(id);
        }
    }
}
