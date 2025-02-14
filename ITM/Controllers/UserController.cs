using ITM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ITM.Controllers
{
    public class UserController : Controller
    {
        CollegeManagementSystemContext _context = new CollegeManagementSystemContext();
        public IActionResult Index()
        {
            var merit = _context.MeritLists.ToList();
            return View(merit);
        }
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Thank you for contacting us! We’ll review your request and reply at the earliest.";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var myuser = _context.Users.Where(x => x.UserEmail == user.UserEmail && x.UserPassword == user.UserPassword).FirstOrDefault();
            if (myuser != null)
            {
                HttpContext.Session.SetString("UserSession", myuser.UserName);
            }
            else
            {
                ViewBag.Message = "Login Failed!";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Your registration is complete. You can now log in and access your account.";
            }
            return RedirectToAction("Login");
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
            var faculty = _context.Faculties.ToList();
            return View(faculty);
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
