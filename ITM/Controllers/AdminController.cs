using ITM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ITM.Controllers
{
    public class AdminController : Controller
    {
        CollegeManagementSystemContext _context = new CollegeManagementSystemContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Forms()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }

        public IActionResult Datatables()
        {
            return View();
        }
        //Courses 
        public IActionResult Courses()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }
        //create
        [HttpGet]
        public IActionResult Course_Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Course_Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course added sucessfully. ";
                return RedirectToAction("Course_Create");
            }
            return View("Course_Create");
        }
        //Facility
        public IActionResult Facility()
        {
            var facility = _context.Facilities.ToList();
            return View(facility);
        }
        //create
        [HttpGet]
        public IActionResult Facility_Form()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Facility_Form(Facility facility)
        {
            if (ModelState.IsValid)
            {
                _context.Facilities.Add(facility);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Facility added sucessfully. ";
                return RedirectToAction("Facility_Form");
            }
            return View("Facility_Form");
        }
        //edit
        [HttpGet]
        public IActionResult Facility_Edit(int id)
        {
            var row = _context.Facilities.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Facility_Edit(Facility facility)
        {
            if (ModelState.IsValid)
            {
                _context.Update(facility);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Facility updated successfully.";
                return RedirectToAction("Facility_Form");
            }

            return View("Facility_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult Facility_Delete(int id)
        {
            var row = _context.Facilities.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Facility_Delete(Facility facility)
        {
            _context.Remove(facility);
            _context.SaveChanges();
            return RedirectToAction("Facility");
        }

        //Admin
        public IActionResult Admin()
        {
            var admin = _context.Admins.ToList();
            return View(admin);
        }

        //Contact
        public IActionResult Contact()
        {
            var contact = _context.Contacts.ToList();
            return View(contact);
        }

     
        //Department
        public IActionResult Depart()
        {
            var dep = _context.Departments.ToList();
            return View(dep);
        }
        //create
        [HttpGet]
        public IActionResult Depart_Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Depart_Create(Department dep)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(dep);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Department added sucessfully. ";
                return RedirectToAction("Depart_Create");
            }
            return View("Depart_Create");
        }
        [HttpGet]
        public IActionResult Depart_Edit(int id)
        {
            var row = _context.Departments.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Depart_Edit(Department dep)
        {
            if (ModelState.IsValid)
            {
                _context.Update(dep);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Department updated successfully.";
                return RedirectToAction("Depart_Edit");
            }

            return View("Depart_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult Depart_Delete(int id)
        {
            var row = _context.Departments.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Depart_Delete(Department dep)
        {
            _context.Remove(dep);
            _context.SaveChanges();
            return RedirectToAction("Depart");
        }

        //Users
        public IActionResult User()
        {
            var user = _context.Users.ToList();
            return View(user);
        }
        [HttpGet]
        public IActionResult User_Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult User_Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "User added sucessfully. ";
                return RedirectToAction("User_Create");
            }
            return View("User_Create");
        }
        //edit
        [HttpGet]
        public IActionResult User_Edit(int id)
        {
            var row = _context.Users.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult User_Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "User updated successfully.";
                return RedirectToAction("User_Edit");
            }

            return View("User_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult User_Delete(int id)
        {
            var row = _context.Users.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult User_Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("User");
        }

        //Roles
        public IActionResult Roles()
        {
            var roles = _context.Roles.ToList();
            return View(roles);
        }

        //Merit
        public IActionResult Merit()
        {
            var merit = _context.MeritLists.ToList();
            return View(merit);
        }

        //create
        [HttpGet]
        public IActionResult Merit_Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Merit_Create(MeritList merit)
        {
            if (ModelState.IsValid)
            {
                _context.MeritLists.Add(merit);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Merit added sucessfully. ";
                return RedirectToAction("Merit_Create");
            }
            return View("Merit_Create");
        }
        [HttpGet]
        public IActionResult Merit_Edit(int id)
        {
            var row = _context.MeritLists.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Merit_Edit(MeritList merit)
        {
            if (ModelState.IsValid)
            {
                _context.Update(merit);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Merit updated successfully.";
                return RedirectToAction("Merit_Edit");
            }

            return View("Merit_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult Merit_Delete(int id)
        {
            var row = _context.MeritLists.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Merit_Delete(MeritList merit)
        {
            _context.Remove(merit);
            _context.SaveChanges();
            return RedirectToAction("Merit");
        }
        //Facility
        public IActionResult Faculty()
        {
            var faculty = _context.Faculties.ToList();
            return View(faculty);
        }
        //create
        [HttpGet]
        public IActionResult Faculty_Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Faculty_Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Faculties.Add(faculty);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Faculty added sucessfully. ";
                return RedirectToAction("Faculty_Create");
            }
            return View("Faculty_Create");
        }
        //edit
        [HttpGet]
        public IActionResult Faculty_Edit(int id)
        {
            var row = _context.Faculties.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Faculty_Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Update(faculty);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Faculty updated successfully.";
                return RedirectToAction("Faculty_Edit");
            }

            return View("Faculty_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult Faculty_Delete(int id)
        {
            var row = _context.Faculties.Find(id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Faculty_Delete(Faculty faculty)
        {
            _context.Remove(faculty);
            _context.SaveChanges();
            return RedirectToAction("Faculty");
        }
    }
}

