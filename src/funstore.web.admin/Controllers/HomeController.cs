using funstore.shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace funstore.web.admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orders()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Carts()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
