namespace SkillSharingApp_BAL.DTOs.ApplicationUser
{
    public class CreateApplicationUserDto_BAL
    {
        public byte[]? ProfilePicture { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public bool ComputerScience { get; set; }
        public bool Math { get; set; }
        public bool Medicine { get; set; }
    }
}
