using ITM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITM.Controllers
{
    public class UserController : Controller
    {
        CollegeManagementSystemContext _context = new CollegeManagementSystemContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Department()
        {
            var department = _context.Departments.ToList();
            return View(department);
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Faculty()
        {
            return View();
        }

        public IActionResult Admission()
        {
            return View();
        }

        public IActionResult Facility()
        {
            var facility = _context.Facilities.ToList();
            return View(facility);
        }
    }
}
