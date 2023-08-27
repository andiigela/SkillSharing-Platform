using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;

namespace SkillSharingApp_DAL.Models
{
    public class Attendance
    {
        public string CreateApplicationUserDto_DALId { get; set; }
        public virtual CreateApplicationUserDto_DAL CreateApplicationUserDto_DAL { get; set; }
        public int WorkshopId { get; set; }
        public virtual Workshop Workshop { get; set; }
        public bool isAttended { get; set; }
    }
}
