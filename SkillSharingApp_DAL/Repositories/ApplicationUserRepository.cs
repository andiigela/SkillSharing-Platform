using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Data;

namespace SkillSharingApp_DAL.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository<CreateApplicationUserDto_DAL>
    {
        private readonly AppDbContext _context;
        public ApplicationUserRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Create(CreateApplicationUserDto_DAL applicationUser)
        {
            _context.CreateApplicationUserDto_DAL.Add(applicationUser);
            _context.SaveChanges();
        }
        public CreateApplicationUserDto_DAL GetById(string id)
        {
            return _context.CreateApplicationUserDto_DAL.Find(id);
        }
    }
}
