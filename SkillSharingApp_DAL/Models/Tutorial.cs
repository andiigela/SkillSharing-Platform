using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSharingApp_DAL.Models
{
    public class Tutorial
    {
        [Key]
        public int TutorialId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Instructions { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("UserId")]
        public string? UserId { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
