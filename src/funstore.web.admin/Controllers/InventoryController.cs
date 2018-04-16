using Funstore.Shared.csharp;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Funstore.Web.Admin.Controllers
{
    public class InventoryController : Controller
    {
        private static List<InventoryItem> items = new List<InventoryItem> {
            new InventoryItem { Id = 1, Name = "Snowstorm in April", Description = "Enjoy this classic outpouring of snow in the middle of spring time" },
            new InventoryItem { Id = 2, Name = "Booming Boomerang", Description = "These boomerangs are great for legitimate fun. They fly faster than the speed of sound so you can enjoy a sonic boom whenever it suits you" }
        } ;

        public IActionResult Index()
        {
            return View(items);
        }

        public IActionResult List()
        {
            return Json(items);
        }
    }
}