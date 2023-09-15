using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SkillSharingApp.BLL.Services;
using SkillSharingApp.Models;
using SkillSharingApp_BAL.DTOs;
using System;
using System.Threading.Tasks;
using AutoMapper;
using SkillSharingApp_DAL.Models;
using SkillSharingApp_DAL.Data;
using System.Diagnostics;

namespace SkillSharingApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public CommentController(ICommentService commentService, UserManager<ApplicationUser> userManager, IMapper mapper, AppDbContext dbContext)
        {
            _commentService = commentService;
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int tutorialId, string content, string userId)
        {
            if (ModelState.IsValid)
            {
                // Get the current user
                var user = await _userManager.GetUserAsync(User);

                // Create a new CommentDto object
                var comment = new CommentDto
                {
                    TutorialId = tutorialId,
                    Content = content,
                    DateTime = DateTime.Now,
                    FirstName = user.FirstName,
                    Lastname = user.Lastname,
                    UserId = user.Id, // Assign the user ID
                };

                // Add the comment to the database
                _commentService.AddComment(comment);

                // Redirect to the Details view of the tutorial
                return RedirectToAction("Details", "Tutorial", new { id = tutorialId });
            }

            // Redirect to the Details view of the tutorial if the comment is not valid
            return RedirectToAction("Details", "Tutorial", new { id = tutorialId });
        }

        [HttpGet]
        public IActionResult EditComment(int commentId)
        {
            var comment = _commentService.GetCommentById(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost]
        public IActionResult EditComment(CommentDto comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _commentService.UpdateComment(comment);

                    TempData["SuccessMessage"] = "Comment updated successfully.";

                    return RedirectToAction("Details", "Tutorial", new { id = comment.TutorialId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the comment: " + ex.Message);
                }
            }

            return View(comment);
        }


        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = _commentService.GetCommentById(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            _commentService.DeleteComment(commentId);
            return RedirectToAction("Details", "Tutorial", new { id = comment.TutorialId });
        }
    }
}
