using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_BAL.Services
{
    public interface IServiceAttendance
    {
        void CreateAttendance(Attendance attendance);
        Attendance GetAttendanceById(int workshopId, string userId);
        List<Attendance> GetAllAttendances();
        List<Attendance> GetUsersOfWorkshops(int workshopId);
        void DeleteAttendance(int workshopId, string userId);
        public List<Workshop> GetWorkshopsAttendedByUser(string userId);
    }
}
