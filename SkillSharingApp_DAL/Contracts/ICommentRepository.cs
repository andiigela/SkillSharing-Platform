using SkillSharingApp_DAL.Models;
using System.Collections.Generic;

namespace SkillSharingApp.DAL.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsByTutorialId(int tutorialId);
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);
        Comment GetCommentById(int commentId); // Added method declaration
    }
}
