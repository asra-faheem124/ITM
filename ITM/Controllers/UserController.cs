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
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(merit);
        }
        public IActionResult About()
        {
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewBag.userName = HttpContext.Session.GetString("UserName");
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
                return RedirectToAction("Contact");

            }
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return RedirectToAction("Contact");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var returnUrl = Url.Action("Index", "Admin");
            var userdata = _context.Users.Where(x => x.Username == user.Username && x.Userpassword == user.Userpassword).FirstOrDefault();
            if (userdata != null)
            {
                HttpContext.Session.SetString("UserID", userdata.UserId.ToString());
                HttpContext.Session.SetString("UserName", userdata.Username);
                HttpContext.Session.SetString("UserEmail", userdata.Useremail);
                HttpContext.Session.SetString("UserEmail", userdata.UserRoleId.ToString());
                if (userdata.UserRoleId == 2)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                ViewBag.Error = "Invalid Credentials!";
                return View();
            }
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
                return RedirectToAction("Signup");
            }
            return View("Signup");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }
        public IActionResult FAQ()
        {
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult Department()
        {
            var department = _context.Departments.ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(department);
        }

        public IActionResult Courses()
        {
            var courses = _context.Courses.ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(courses);
        }

        public IActionResult Faculty()
        {
            var faculty = _context.Faculties.ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(faculty);
        }

        public IActionResult Facility()
        {
            var facility = _context.Facilities.ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(facility);
        }

        [HttpGet]
        public IActionResult AdmissionForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdmissionForm(Admission admission)
        {
            if (ModelState.IsValid)
            {
                _context.Admissions.Add(admission);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Your registration is complete. You can now log in and access your account.";
                return RedirectToAction("AdmissionForm");

            }
            return View("AdmissionForm");
        }

    }
}
