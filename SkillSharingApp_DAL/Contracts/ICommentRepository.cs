using SkillSharingApp_DAL.Models;
using System.Collections.Generic;

namespace SkillSharingApp.DAL.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentsByTutorialId(int tutorialId);
    }
}
