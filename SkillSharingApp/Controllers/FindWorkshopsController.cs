using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSharingApp.Models;
using SkillSharingApp_BAL.Services;
using SkillSharingApp_DAL.DAL_DTOs.ApplicationUser;
using SkillSharingApp_DAL.Models;

namespace SkillSharingApp.Controllers
{
    public class FindWorkshopsController : Controller
    {
        private readonly IServiceWorkshop _serviceWorkshop;
        private readonly ApplicationManager _userManager;
        private readonly IServiceAttendance _serviceAttendance;
        private readonly IServiceApplicationUser _serviceApplicationUser;
        public FindWorkshopsController(IServiceWorkshop _serviceWorkshop, ApplicationManager _userManager,
            IServiceAttendance serviceAttendance, IServiceApplicationUser serviceApplicationUser)
        {
            this._serviceWorkshop = _serviceWorkshop;
            this._userManager = _userManager;
            _serviceAttendance = serviceAttendance;
            _serviceApplicationUser = serviceApplicationUser;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult SearchName(string name)
        {
            var currentUser = getLoggedInUser();
            if (currentUser == null) return NotFound("User not exists");
            var _workshops = _serviceWorkshop.WorkShopsByNamePublic(name, currentUser.Id);
            return View(_workshops);
        }
        [Authorize]
        public async Task<IActionResult> AttendWorkshop(int id)
        {
            var currentUser = getLoggedInUser();
            if (currentUser == null) return NotFound("User not exists");
            var workshop = _serviceWorkshop.GetWorkShopById(id);
            if (workshop == null) return NotFound("Workshop not found !");
            AttendWorkshopByUser(currentUser, workshop);
            return RedirectToAction("SearchName", new { name = workshop.Title });
        }
        public void AttendWorkshopByUser(ApplicationUser currentUser, Workshop workshop)
        {
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
            var attendance = new Attendance
            {
                CreateApplicationUserDto_DALId = applicationUser.Id,
                CreateApplicationUserDto_DAL = applicationUser,
                WorkshopId = workshop.Id,
                Workshop = workshop,
                isAttended = true
            };
            var checkAttendance = _serviceAttendance.GetAttendanceById(workshop.Id, currentUser.Id);
            if (checkAttendance != null) return;
            _serviceAttendance.CreateAttendance(attendance);
        }
        public ApplicationUser getLoggedInUser()
        {
            var currentUser = _userManager.GetUserAsync(User).Result;
            return currentUser;
        }
    }
}
