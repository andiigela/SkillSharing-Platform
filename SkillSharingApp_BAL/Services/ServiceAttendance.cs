using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_BAL.Services
{
    public class ServiceAttendance : IServiceAttendance
    {
        private readonly IAttendanceRepository<Attendance> _attendanceRepository;
        public ServiceAttendance(IAttendanceRepository<Attendance> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public void CreateAttendance(Attendance attendance)
        {
            if (attendance == null) return;
            _attendanceRepository.Create(attendance);
        }
        public List<Attendance> GetAllAttendances()
        {
            return _attendanceRepository.GetAll();
        }
        public Attendance GetAttendanceById(int workshopId, string userId)
        {
            if (userId.Equals("") || userId == null) return null;
            if (workshopId == 0 || workshopId == null) return null;
            return _attendanceRepository.GetById(workshopId, userId);
        }
        public List<Attendance> GetUsersOfWorkshops(int workshopId)
        {
            if (workshopId == 0 || workshopId == null) return null;
            return _attendanceRepository.GetUsersOfWorkshops(workshopId);
        }
        public void DeleteAttendance(int workshopId, string userId)
        {
            if (userId.Equals("") || userId == null) return;
            if (workshopId == 0 || workshopId == null) return;
            _attendanceRepository.Delete(workshopId, userId);
        }
        public List<Workshop> GetWorkshopsAttendedByUser(string userId)
        {
            if (userId.Equals("") || userId == null) return null;
            return _attendanceRepository.GetWorkshopsAttendedByUser(userId);
        }
    }
}
