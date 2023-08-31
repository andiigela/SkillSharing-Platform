using SkillSharingApp_DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSharingApp_DAL.DAL_DTOs.ApplicationUser
{
    public class CreateApplicationUserDto_DAL
    {
        public string Id { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public bool ComputerScience { get; set; }
        public bool Math { get; set; }
        public bool Medicine { get; set; }
    }
}
