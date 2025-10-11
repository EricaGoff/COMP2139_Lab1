using Microsoft.AspNetCore.Mvc;

namespace COMP2139_Lab1.Controllers
{
    public class Home1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}