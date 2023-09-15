using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSharingApp.Models;
using SkillSharingApp_BAL.Services;

namespace SkillSharingApp.Controllers
{
    public class AttendedWorkshopsController : Controller
    {
        private readonly IServiceAttendance _serviceAttendance;
        private readonly IServiceWorkshop _serviceWorkshop;
        private readonly ApplicationManager _applicationManager;
        public AttendedWorkshopsController(IServiceAttendance serviceAttendance, ApplicationManager applicationManager, IServiceWorkshop serviceWorkshop)
        {
            _serviceAttendance = serviceAttendance;
            _applicationManager = applicationManager;
            _serviceWorkshop = serviceWorkshop;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _applicationManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("WorkshopNotFound");
            var attendedWorkshopsByUser = _serviceAttendance.GetWorkshopsAttendedByUser(currentUser.Id);
            return View(attendedWorkshopsByUser);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Workshop(int workshopId)
        {
            var workshop = _serviceWorkshop.GetWorkShopById(workshopId);
            return View(workshop);
        }
        [Authorize]
        public IActionResult UnAttend(int workshopId, string userId)
        {
            _serviceAttendance.DeleteAttendance(workshopId, userId);
            return RedirectToAction("Index");
        }
        public IActionResult WorkshopNotFound()
        {
            return View();
        }
    }
}
