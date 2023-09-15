using SkillSharingApp_BAL.DTOs;

namespace SkillSharingApp_BAL.Services
{
    public interface ITutorialService
    {
        IEnumerable<TutorialDto> GetAllTutorials();
        TutorialDto GetTutorialById(int tutorialId);
        void AddTutorial(TutorialDto tutorial);
        void UpdateTutorial(TutorialDto tutorial);
        void DeleteTutorial(int tutorialId);
    }
}