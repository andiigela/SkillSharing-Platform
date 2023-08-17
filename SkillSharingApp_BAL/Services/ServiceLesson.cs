using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingApp_BAL.Services
{
    public class ServiceLesson : IServiceLesson
    {
        private readonly ILessonRepository<Lesson> _lessonRepository;
        public ServiceLesson(ILessonRepository<Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        //
        public Lesson CreateLesson(Lesson lesson)
        {
            try
            {
                if (lesson == null) throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _lessonRepository.Create(lesson);
            return lesson;
        }
        //
        public IEnumerable<Lesson> GetLessons()
        {
            return _lessonRepository.GetAll();
        }
        //
        public Lesson GetLesson(int id)
        {
            try
            {
                if (id == 0 || id == null) throw new ArgumentNullException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _lessonRepository.GetById(id);
        }
        public void UpdateLesson(Lesson lesson)
        {
            try
            {
                if (lesson == null) throw new ArgumentNullException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            _lessonRepository.Update(lesson);
        }
        public void DeleteLesson(int id)
        {
            try
            {
                if (id == 0 || id == null) throw new ArgumentNullException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            _lessonRepository.DeleteById(id);
        }
    }
}
