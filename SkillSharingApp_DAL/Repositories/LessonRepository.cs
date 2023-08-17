using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Data;
using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingApp_DAL.Repositories
{
    public class LessonRepository : ILessonRepository<Lesson>
    {
        private readonly AppDbContext _context;
        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }
        public Lesson Create(Lesson lesson)
        {
            if (lesson == null) return null;
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return lesson;
        }
        public void DeleteById(int id)
        {
            if (id == 0 || id == null) return;
            var lessonInDb = _context.Lessons.Find(id);
            _context.Lessons.Remove(lessonInDb);
            _context.SaveChanges();
        }
        public IEnumerable<Lesson> GetAll()
        {
            return _context.Lessons.ToList();
        }
        public Lesson GetById(int id)
        {
            if (id == 0 || id == null) return null;
            return _context.Lessons.FirstOrDefault(lesson => lesson.Id == id);
        }
        public void Update(Lesson lesson)
        {
            if (lesson == null) return;
            var lessonInDb = _context.Lessons.Find(lesson.Id);
            _context.Lessons.Update(lessonInDb);
            _context.SaveChanges();
        }
    }
}
