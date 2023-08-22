using AutoMapper;
using SkillSharingApp_BAL.DTOs;
using SkillSharingApp_DAL.Contracts;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp_BAL.Services
{
    public class TutorialService : ITutorialService
    {
        private readonly ITutorialRepository _tutorialRepository;
        private readonly IMapper _mapper;

        public TutorialService(ITutorialRepository tutorialRepository, IMapper mapper)
        {
            _tutorialRepository = tutorialRepository;
            _mapper = mapper;
        }
        public IEnumerable<TutorialDto> GetAllTutorials()
        {
            var tutorials = _tutorialRepository.GetAllTutorials();
            return _mapper.Map<IEnumerable<TutorialDto>>(tutorials);
        }
        public TutorialDto GetTutorialById(int tutorialId)
        {
            var tutorial = _tutorialRepository.GetTutorialById(tutorialId);
            return _mapper.Map<TutorialDto>(tutorial);
        }
        public void AddTutorial(TutorialDto tutorial)
        {
            var tutorialEntity = new Tutorial
            {
                Title = tutorial.Title,
                Description = tutorial.Description,
                Duration = tutorial.Duration,
                Instructions = tutorial.Instructions,
                VideoUrl = tutorial.VideoUrl,
                ImageUrl = tutorial.ImageUrl,
                UserId = tutorial.UserId // Include the UserId property
            };

            // Map the comments from TutorialDto to Comment and add to the tutorialEntity
            tutorialEntity.Comments = tutorial.Comments.Select(c => new Comment
            {
                // Map the properties of CommentDto to Comment as needed
            }).ToList();

            _tutorialRepository.AddTutorial(tutorialEntity);
            _tutorialRepository.SaveChanges();
        }
        public void UpdateTutorial(TutorialDto tutorial)
        {
            var tutorialEntity = _mapper.Map<Tutorial>(tutorial);
            _tutorialRepository.UpdateTutorial(tutorialEntity);
            _tutorialRepository.SaveChanges();
        }
        public void DeleteTutorial(int tutorialId)
        {
            _tutorialRepository.DeleteTutorial(tutorialId);
            _tutorialRepository.SaveChanges();
        }
    }
}