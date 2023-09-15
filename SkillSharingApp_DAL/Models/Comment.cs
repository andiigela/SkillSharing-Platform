using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSharingApp_DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int TutorialId { get; set; } // Foreign key to Tutorial
        public Tutorial Tutorial { get; set; } // Navigation property

        [ForeignKey("UserId")]
        public string UserId { get; set; } // Foreign key to AspNetUsers

        [Required]
        public string FirstName { get; set; } // User's first name

        [Required]
        public string Lastname { get; set; } // User's last name

        public DateTime DateTime { get; set; }

        [MaxLength]
        public string Content { get; set; }

        public bool IsEdited { get; set; }
    }
}
