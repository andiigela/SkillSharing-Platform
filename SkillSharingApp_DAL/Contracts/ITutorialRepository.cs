using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_DAL.Contracts
{
    public interface ITutorialRepository
    {
        IEnumerable<Tutorial> GetAllTutorials();
        Tutorial GetTutorialById(int tutorialId);
        void AddTutorial(Tutorial tutorial);
        void UpdateTutorial(Tutorial tutorial);
        void DeleteTutorial(int tutorialId);
        void SaveChanges();
    }
}