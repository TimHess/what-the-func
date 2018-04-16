using Funstore.Shared.csharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Funstore.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogTrace("Requested the Home page");
            return View();
        }

        public IActionResult Orders()
        {
            ViewData["Message"] = "View and Process Orders";

            return View();
        }

        public IActionResult Carts()
        {
            
            ViewData["Message"] = "View Live Shopping Carts";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
