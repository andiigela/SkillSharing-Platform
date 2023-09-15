using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingApp_BAL.DTOs
{
    public class TutorialDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Instructions { get; set; }
        public string VideoUrl { get; set; }
        public string ImageUrl { get; set; }
        public List<CommentDto> Comments { get; set; }
        public string UserId { get; set; }
    }
}
