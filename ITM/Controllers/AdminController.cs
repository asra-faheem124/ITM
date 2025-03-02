using ITM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.Arm;

namespace ITM.Controllers
{
    public class AdminController : Controller
    {
        CollegeManagementSystemContext _context = new CollegeManagementSystemContext();
        IWebHostEnvironment env;
        public AdminController(IWebHostEnvironment env)
        {
            this.env = env;
        }
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
        //admission
        public IActionResult Admission()
        {
            var adm = _context.Admissions.Include(f => f.AdmCourse).ToList();
            return View(adm);

        }
        [HttpGet]
        public IActionResult Approve(int id)
        {
            var admission = _context.Admissions.FirstOrDefault(a => a.Id == id);
            if (admission == null)
            {
                return NotFound();
            }
            return View(admission);
        }
        [HttpPost]
        public IActionResult Approve(Admission adm)
        {
            var admission = _context.Admissions.FirstOrDefault(a => a.Id == adm.Id);
            if (admission == null)
            {
                return NotFound();
            }
            admission.AdmissionStatus = "Approved";
            _context.SaveChanges();
            //Email Sending
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com",587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("asrafaheem125@gmail.com", "zrzxvcsktwunvlwv");
            MailMessage Msg = new MailMessage("asrafaheem125@gmail.com", admission.Email);
            Msg.Subject = "ITM college Management System";
            string CheckStatusUrl = Url.Action("CheckStatus", "User", new { id = admission.Id }, Request.Scheme);
            Msg.Body = admission.Name + "\n Your admission is approved. \n Your registration id is: " + admission.Id + "\n " +
                "To check further details visit on: " + CheckStatusUrl;
            smtpClient.Send(Msg);
            return RedirectToAction("CheckStatus","User");
        }
        //reject
        [HttpGet]
        public IActionResult Reject(int id)
        {
            var admission = _context.Admissions.FirstOrDefault(a => a.Id == id);
            if (admission == null)
            {
                return NotFound();
            }
            return View(admission);
        }

        [HttpPost]
        public IActionResult Reject(Admission adm)
        {
            var admission = _context.Admissions.FirstOrDefault(a => a.Id == adm.Id);
            if (admission == null)
            {
                return NotFound();
            }
            admission.AdmissionStatus = "Rejected";
            _context.SaveChanges();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("asrafaheem125@gmail.com", "zrzxvcsktwunvlwv");
            MailMessage Msg = new MailMessage("asrafaheem125@gmail.com", admission.Email);
            Msg.Subject = "ITM college Management System";
            string CheckStatusUrl = Url.Action("CheckStatus", "User", new { id = admission.Id }, Request.Scheme);
            Msg.Body = admission.Name + "\n Your admission is rejected." +
                "To check further details visit on: " + CheckStatusUrl;
            smtpClient.Send(Msg);
            return RedirectToAction("CheckStatus", "User");
        }

        //Courses 
        public IActionResult Courses()
        {
            var courses = _context.CourseItms.Include(f => f.CourseDepart).ToList();
            return View(courses);
        }
        //create
        [HttpGet]
        public IActionResult Course_Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Course_Create(CourseItmView course)
        {
			string fileName = "";
			if (course.Courseimage != null)
			{
				string folder = Path.Combine(env.WebRootPath, "assets", "extra-images");
				fileName = Guid.NewGuid().ToString() + "_" + course.Courseimage.FileName;
				string filePath = Path.Combine(folder, fileName);
				course.Courseimage.CopyTo(new FileStream(filePath, FileMode.Create));
                CourseItm cou = new CourseItm()
                {
					Coursename = course.Coursename,
					Courseduration = course.Courseduration,
					Coursefees = course.Coursefees,
                    Coursedesc = course.Coursedesc,
                    Courseteacher = course.Courseteacher,
                    CourseDepartId = course.CourseDepartId,
					Courseimage = fileName
				};
				_context.CourseItms.Add(cou);
				_context.SaveChanges();
				TempData["SuccessMessage"] = "Course added sucessfully. ";
				return RedirectToAction("Course_Create");
			}
			ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.CourseDepartId);
            return View("Course_Create");
        }
        //edit
        [HttpGet]
        public IActionResult Course_Edit(int id)
        {
            var row = _context.CourseItms.Include(f => f.CourseDepart).FirstOrDefault(f => f.Courseid == id);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", row.CourseDepartId);
            return View(row);
        }
        [HttpPost]
        public IActionResult Course_Edit(CourseItm course)
        {
            if (ModelState.IsValid)
            {
                _context.Update(course);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Course updated successfully.";
                return RedirectToAction("Course_Edit");
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View("Course_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult Course_Delete(int id)
        {
            var row = _context.CourseItms.Include(f => f.CourseDepart).FirstOrDefault(f => f.Courseid == id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Course_Delete(CourseItm course)
        {
            _context.Remove(course);
            _context.SaveChanges();
            ViewBag.DepartmentName = course.CourseDepart?.DepartmentName ?? "Not Assigned";
            return RedirectToAction("Courses");
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
        public IActionResult Facility_Form(FacilityView facilityView)
        {
            string fileName = "";
            if (facilityView.FacilityImg != null)
            {
                string folder = Path.Combine(env.WebRootPath, "assets", "extra-images");
                fileName = Guid.NewGuid().ToString()+"_"+facilityView.FacilityImg.FileName;
                string filePath = Path.Combine(folder, fileName);
                facilityView.FacilityImg.CopyTo(new FileStream(filePath, FileMode.Create));
                Facility fac = new Facility()
                {
                    FacilityName = facilityView.FacilityName,
                    FacilityDesc = facilityView.FacilityDesc,
                    FacilityImg = fileName
                };
                _context.Facilities.Add(fac);
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
                return RedirectToAction("Facility_Edit");
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
        public IActionResult Depart_Create(DepartmentView dep)
        {
            string fileName = "";
            if (dep.DepartmentImg != null)
            {
                string folder = Path.Combine(env.WebRootPath, "assets", "extra-images");
                fileName = Guid.NewGuid().ToString() + "_" + dep.DepartmentImg.FileName;
                string filePath = Path.Combine(folder, fileName);
                dep.DepartmentImg.CopyTo(new FileStream(filePath, FileMode.Create));
                Department depart = new Department()
                {
                    DepartmentName = dep.DepartmentName,
                    DepartmentDesc = dep.DepartmentDesc,
                    DepartmentTeacher = dep.DepartmentTeacher,
                    DepartmentImg = fileName
                };
                _context.Departments.Add(depart);
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
            var faculty = _context.Faculties.Include(f => f.Department).ToList();
            return View(faculty);
        }
        //create
        [HttpGet]
        public IActionResult Faculty_Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Faculty_Create(FacultyView faculty)
        {
            string fileName = "";
            if (faculty.FacultyImg != null)
            {
                string folder = Path.Combine(env.WebRootPath, "assets", "extra-images");
                fileName = Guid.NewGuid().ToString() + "_" + faculty.FacultyImg.FileName;
                string filePath = Path.Combine(folder, fileName);
                faculty.FacultyImg.CopyTo(new FileStream(filePath, FileMode.Create));
                Faculty fac = new Faculty()
                {
                    FacultyName = faculty.FacultyName,
                    Designation = faculty.Designation,
                    Experience = faculty.Experience,
                    Qualification = faculty.Qualification,
                    FacultyImg = fileName
                };
                _context.Faculties.Add(fac);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Fcaulty added sucessfully. ";
                return RedirectToAction("Faculty_Create");
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", faculty.DepartmentId);
            return View("Faculty_Create");
        }
        //edit
        [HttpGet]
        public IActionResult Faculty_Edit(int id)
        {
            var row = _context.Faculties.Include(f => f.Department).FirstOrDefault(f => f.FacultyId == id);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", row.DepartmentId);
            return View(row);
        }
        [HttpPost]
        public IActionResult Faculty_Edit(Faculty faculty)
        {
            if (ModelState.IsValid == false)
            {
                _context.Update(faculty);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Faculty updated successfully.";
                return RedirectToAction("Faculty_Edit");
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View("Faculty_Edit");
        }
        //delete
        [HttpGet]
        public IActionResult Faculty_Delete(int id)
        {
            var row = _context.Faculties.Include(f => f.Department).FirstOrDefault(f => f.FacultyId == id);
            return View(row);
        }
        [HttpPost]
        public IActionResult Faculty_Delete(Faculty faculty)
        {
            _context.Remove(faculty);
            _context.SaveChanges();
            ViewBag.DepartmentName = faculty.Department?.DepartmentName ?? "Not Assigned";
            return RedirectToAction("Faculty");
        }
    }
}

