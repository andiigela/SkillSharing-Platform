using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSharingApp.Models;
using SkillSharingApp_BAL.Services;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly IServiceWorkshop _serviceWorkshop;
        private readonly IServiceApplicationUser _serviceApplicationUser;
        private readonly IServiceAttendance _serviceAttendances;
        private readonly ApplicationManager _userManager;
        public WorkshopsController(IServiceWorkshop serviceWorkshop,
            IServiceApplicationUser serviceApplicationUser,
            ApplicationManager userManager,
            IServiceAttendance serviceAttendances
            )
        {
            _serviceWorkshop = serviceWorkshop;
            _serviceApplicationUser = serviceApplicationUser;
            _userManager = userManager;
            _serviceAttendances = serviceAttendances;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return RedirectToAction("WorkshopNotFound");
            var workshopList = _serviceWorkshop.GetAllWorkshops(currentUser.Id);
            foreach (var w in workshopList)
            {
                if (w.Availability < DateTime.Now)
                {
                    _serviceWorkshop.changeWorkShopAvailability(w);
                }
            }
            return View(workshopList);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(Workshop workshop)
        {
            if (workshop == null) return NotFound();
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return NotFound("User not exists");
            var applicationUser = _serviceApplicationUser.getApplicationUserById(currentUser.Id);
            if (applicationUser == null)
            {
                applicationUser = new CreateApplicationUserDto_DAL
                {
                    Id = currentUser.Id,
                    ProfilePicture = currentUser.ProfilePicture,
                    FirstName = currentUser.FirstName,
                    Lastname = currentUser.Lastname,
                    ComputerScience = currentUser.ComputerScience,
                    Math = currentUser.Math,
                    Medicine = currentUser.Medicine,
                    Attendances = currentUser.Attendances
                };
            }
            workshop.CreateApplicationUserDto_DALId = applicationUser.Id;
            workshop.CreateApplicationUserDto_DAL = applicationUser;
            if (ModelState.IsValid)
            {
                if (workshop.Availability > DateTime.Now)
                {
                    _serviceWorkshop.CreateWorkShop(workshop);
                    return RedirectToAction("Index");
                }
                return BadRequest(new ProblemDetails { Title = "Date must be higher than Now" });
            }
            return View(workshop);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null) return NotFound("Workshop id doesn't exist");
            _serviceWorkshop.DeleteWorkShopById(id);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null) return NotFound("Workshop id doesn't exist");
            var workshop = _serviceWorkshop.GetWorkShopById(id);
            if (workshop.Availability < DateTime.Now) workshop.isVisible = 0;
            return View(workshop);
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditWorkshop(Workshop workshop)
        {
            if (workshop == null) return NotFound("Workshop does not exist");
            if (workshop.Availability < DateTime.Now) workshop.isVisible = 0;
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return NotFound("User not exists");
            var applicationUser = _serviceApplicationUser.getApplicationUserById(currentUser.Id);
            workshop.CreateApplicationUserDto_DALId = applicationUser.Id;
            workshop.CreateApplicationUserDto_DAL = applicationUser;
            _serviceWorkshop.UpdateWorkShop(workshop);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteImage(int workshopId, string imageId)
        {
            _serviceWorkshop.DeleteWorkshopImage(workshopId, imageId);
            return RedirectToAction("Edit", new { id = workshopId });
        }
        [Authorize]
        [HttpGet]
        public IActionResult Attendances(int workshopId)
        {
            var usersAttendances = _serviceAttendances.GetUsersOfWorkshops(workshopId);
            if (usersAttendances == null) return NotFound("There is no Users that Attended your Workshop");
            return View(usersAttendances);
        }
        [Authorize]
        [HttpGet]
        public IActionResult RemoveAttendance(int workshopId, string userId)
        {
            _serviceAttendances.DeleteAttendance(workshopId, userId);
            return RedirectToAction("Attendances", new { workshopId = workshopId });
        }
        public IActionResult WorkshopNotFound()
        {
            return View();
        }

    }
}
