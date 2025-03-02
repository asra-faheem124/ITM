using ITM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
                HttpContext.Session.SetString("User_Role_Id", userdata.UserRoleId.ToString());
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
            var courses = _context.CourseItms.ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(courses);
        }

        public IActionResult Faculty()
        {
            var faculties = _context.Faculties.Include(f => f.Department).ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(faculties);
        }


        public IActionResult Facility()
        {
            var facility = _context.Facilities.ToList();
            ViewBag.userName = HttpContext.Session.GetString("UserName");
            return View(facility);
        }

        public IActionResult AdmissionForm()
        {
            ViewBag.Courses = new SelectList(_context.CourseItms, "Courseid", "Coursename");
            return View();
        }

        [HttpPost]
        public IActionResult AdmissionForm(Admission admission)
        {
            if (ModelState.IsValid == false)
            {
                _context.Admissions.Add(admission);
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Your registration is complete. Your Registration Number is {admission.Id}. Use this to check your status.";
                return RedirectToAction("AdmissionForm");
            }
            ViewBag.Courses = new SelectList(_context.CourseItms, "Courseid", "Coursename", admission.AdmCourseId);
            return View("AdmissionForm");
        }

        [HttpGet]
        public IActionResult CheckStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckStatus(int admissionId)
        {
            var admission = _context.Admissions.FirstOrDefault(a => a.Id == admissionId);

            if (admission == null)
            {
                ViewBag.Message = "No record found for the provided registration number.";
                return View();
            }

            return View("AdmissionDetails", admission);
        }


    }
}
