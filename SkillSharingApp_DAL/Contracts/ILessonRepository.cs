using SkillSharingApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillSharingApp_DAL.Contracts
{
    public interface ILessonRepository<Lesson>
    {
        Lesson Create(Lesson lesson);
        IEnumerable<Lesson> GetAll();
        Lesson GetById(int id);
        void Update(Lesson lesson);
        void DeleteById(int id);
    }
}
