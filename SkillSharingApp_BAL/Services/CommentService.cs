using SkillSharingApp_BAL.DTOs;
using SkillSharingApp.DAL.Repositories;
using SkillSharingApp_DAL.Models;
using AutoMapper;

namespace SkillSharingApp.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public IEnumerable<CommentDto> GetCommentsByTutorialId(int tutorialId)
        {
            var comments = _commentRepository.GetCommentsByTutorialId(tutorialId);
            // Map the Comment entities to CommentDto objects
            var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
            return commentDtos;
        }
    }

}
