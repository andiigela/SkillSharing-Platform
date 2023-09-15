using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Data;
using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SkillSharingApp_DAL.Repositories
{
    public class TutorialRepository : ITutorialRepository
    {
        private readonly AppDbContext _context;

        public TutorialRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tutorial> GetAllTutorials()
        {
            return _context.Tutorials
                .Include(t => t.UserId)
                .ToList();
        }

        public Tutorial GetTutorialById(int tutorialId)
        {
            return _context.Tutorials.Find(tutorialId);
        }

        public void AddTutorial(Tutorial tutorial)
        {
            _context.Tutorials.Add(tutorial);
        }

        public void UpdateTutorial(Tutorial tutorial)
        {
            _context.Entry(tutorial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DeleteTutorial(int tutorialId)
        {
            var tutorial = _context.Tutorials.Find(tutorialId);
            if (tutorial != null)
            {
                _context.Tutorials.Remove(tutorial);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}