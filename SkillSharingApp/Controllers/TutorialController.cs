using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SkillSharingApp_BAL.Services;
using SkillSharingApp.Models;

namespace SkillSharingApp.Controllers
{
    public class TutorialController : Controller
    {
        private readonly ITutorialService _tutorialService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public TutorialController(ITutorialService tutorialService, ICommentService commentService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _tutorialService = tutorialService;
            _commentService = commentService;
            _mapper = mapper;
            _userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var tutorials = _tutorialService.GetAllTutorials();
            var tutorialDtos = _mapper.Map<IEnumerable<TutorialDto>>(tutorials);
            return View(tutorialDtos);
        }

        [Authorize]
        public IActionResult Create()
        {
            var tutorial = new TutorialDto();
            return View(tutorial);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TutorialDto tutorial)
        {
            if (tutorial == null)
            {
                throw new ArgumentNullException(nameof(tutorial));
            }
            var currentUser = await _userManager.GetUserAsync(User);
            tutorial.UserId = currentUser.Id;

            try
            {
                if (tutorial.Comments == null)
                {
                    tutorial.Comments = new List<CommentDto>();
                }

                _tutorialService.AddTutorial(tutorial);
                TempData["SuccessMessage"] = "Tutorial created successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving the tutorial: " + ex.Message);
            }
    
            return View(tutorial);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var tutorial = _tutorialService.GetTutorialById(id);
            if (tutorial == null)
            {
                return NotFound();
            }

            return View(tutorial);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Edit(TutorialDto tutorial)
        {
            
                try
                {
                    _tutorialService.UpdateTutorial(tutorial);
                    TempData["SuccessMessage"] = "Tutorial updated successfully.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the tutorial: " + ex.Message);
            }

            return View(tutorial);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                _tutorialService.DeleteTutorial(id);
                TempData["SuccessMessage"] = "Tutorial deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the tutorial: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var tutorial = _tutorialService.GetTutorialById(id);
            if (tutorial == null)
            {
                return NotFound();
            }

            var commentDtos = _commentService.GetCommentsByTutorialId(id);
            tutorial.Comments = commentDtos.ToList();
            return View(tutorial);
        }
        /* Delete and Details */
    }
}
