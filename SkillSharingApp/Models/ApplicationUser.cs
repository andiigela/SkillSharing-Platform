using Microsoft.AspNetCore.Identity;
using SkillSharingApp_DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSharingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[]? ProfilePicture { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public bool ComputerScience { get; set; }
        public bool Math { get; set; }
        public bool Medicine { get; set; }
        [NotMapped]
        public List<Attendance> Attendances { get; set; }
    }
}
