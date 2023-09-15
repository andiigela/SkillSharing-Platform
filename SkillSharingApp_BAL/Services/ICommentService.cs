using SkillSharingApp_BAL.DTOs;
using SkillSharingApp_DAL.Models;
using System.Collections.Generic;

namespace SkillSharingApp.BLL.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetCommentsByTutorialId(int tutorialId);
        void AddComment(CommentDto comment);
        void UpdateComment(CommentDto comment);
        void DeleteComment(int commentId);
        CommentDto GetCommentById(int commentId);
    }
}
