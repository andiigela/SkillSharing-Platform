using SkillSharingApp_BAL.DTOs;
using SkillSharingApp_DAL.Models;
using System.Collections.Generic;

namespace SkillSharingApp.BLL.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetCommentsByTutorialId(int tutorialId);
    }
}
