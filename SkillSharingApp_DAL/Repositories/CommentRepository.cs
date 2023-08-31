using Microsoft.EntityFrameworkCore;
using SkillSharingApp_DAL.Data;
using SkillSharingApp_DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SkillSharingApp.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Comment> GetCommentsByTutorialId(int tutorialId)
        {
            return _dbContext.Comments
                .Where(c => c.TutorialId == tutorialId)
                .ToList();
        }
    }
}
