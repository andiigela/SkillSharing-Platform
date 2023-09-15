using System;

namespace SkillSharingApp_BAL.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }

        public int TutorialId { get; set; } // Foreign key to TutorialDto

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public bool IsEdited { get; set; }
    }
}
