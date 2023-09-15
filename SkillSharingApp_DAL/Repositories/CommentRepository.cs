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

        public void AddComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            var comment = _dbContext.Comments.Find(commentId);
            if (comment != null)
            {
                _dbContext.Comments.Remove(comment);
                _dbContext.SaveChanges();
            }
        }

        public Comment GetCommentById(int commentId)
        {
            return _dbContext.Comments.FirstOrDefault(c => c.Id == commentId);
        }
    }
}
