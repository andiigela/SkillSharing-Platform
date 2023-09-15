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

        public void AddComment(CommentDto comment)
        {
            var commentEntity = _mapper.Map<Comment>(comment);
            _commentRepository.AddComment(commentEntity);
        }

        public void UpdateComment(CommentDto comment)
        {
            var existingComment = _commentRepository.GetCommentById(comment.Id);
            if (existingComment != null)
            {
                existingComment.Content = comment.Content;
                existingComment.IsEdited = true;
                _commentRepository.UpdateComment(existingComment);
            }
            else
            {
                throw new Exception("Comment not found");
            }
        }


        public void DeleteComment(int commentId)
        {
            _commentRepository.DeleteComment(commentId);
        }

        public CommentDto GetCommentById(int commentId)
        {
            var comment = _commentRepository.GetCommentById(commentId);
            // Map the Comment entity to CommentDto object
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }
    }

}
