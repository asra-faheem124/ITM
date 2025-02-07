using Microsoft.AspNetCore.Mvc;

namespace ITM.Controllers
{
    public class AdminController : Controller
    {
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
    }
}
