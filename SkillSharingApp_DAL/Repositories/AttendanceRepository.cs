using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Data;
using SkillSharingApp_DAL.Models;
using System.Data.Entity;

namespace SkillSharingApp_DAL.Repositories
{
    public class AttendanceRepository : IAttendanceRepository<Attendance>
    {
        private readonly AppDbContext _context;
        public AttendanceRepository(AppDbContext context)
        {
            this._context = context;
        }
        public void Create(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }
        public List<Attendance> GetAll()
        {
            return _context.Attendances.ToList();
        }
        public Attendance GetById(int workshopId, string userId)
        {
            return _context.Attendances
                .Include(a => a.CreateApplicationUserDto_DAL)
                .Include(a => a.Workshop)
                .FirstOrDefault(a => a.WorkshopId == workshopId && a.CreateApplicationUserDto_DALId == userId);
        }
        public List<Attendance> GetUsersOfWorkshops(int workshopId)
        {
            return _context.Attendances
                    .Where(a => a.WorkshopId == workshopId)
                    .ToList();
        }
        public List<Workshop> GetWorkshopsAttendedByUser(string userId)
        {
            return _context.Attendances
                    .Where(a => a.CreateApplicationUserDto_DALId == userId)
                    .Include(a => a.Workshop)
                    .Select(a => a.Workshop)
                    .ToList();
        }
        public void Delete(int workshopId, string userId)
        {
            var attendanceById = GetById(workshopId, userId);
            _context.Attendances.Remove(attendanceById);
            _context.SaveChanges();
        }
    }
}
