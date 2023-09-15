using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_DAL.Contracts
{
    public interface IAttendanceRepository<Attendance>
    {
        void Create(Attendance attendance);
        Attendance GetById(int workshopId, string userId);
        List<Attendance> GetAll();
        List<Attendance> GetUsersOfWorkshops(int workshopId);
        void Delete(int workshopId, string userId);
        public List<Workshop> GetWorkshopsAttendedByUser(string userId);
    }
}
