using Funstore.Shared.csharp;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Funstore.Web.Admin.Controllers
{
    public class InventoryController : Controller
    {
        private static List<InventoryItem> items = new List<InventoryItem> {
            new InventoryItem { Id = 1, Name = "Snowstorm in April", Description = "Enjoy this classic outpouring of snow in the middle of spring time", FontAwesomeIcon = "snowflake" },
            new InventoryItem { Id = 2, Name = "Old School Bomb", Description = "Is it a bowling ball with a string attached, or is it a bomb? Order yours today to find out!", FontAwesomeIcon = "bomb" },
            new InventoryItem { Id = 3, Name = "git Jokes", Description = "A random assortment of git-related jokes. Free samples include: 'git-fetch: no training required' and 'git happens'", FontAwesomeIcon = "code-branch"},
            new InventoryItem { Id = 4, Name = "The Cloud", Description = "Spoiler alert: its just somebody else's computer(s)", FontAwesomeIcon = "cloud" }
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