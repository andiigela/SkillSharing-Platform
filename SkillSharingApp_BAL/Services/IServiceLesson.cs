using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingApp_BAL.Services
{
    public interface IServiceLesson
    {
        Lesson CreateLesson(Lesson lesson);
        IEnumerable<Lesson> GetLessons();
        Lesson GetLesson(int id);
        void UpdateLesson(Lesson lesson);
        void DeleteLesson(int id);
    }
}
