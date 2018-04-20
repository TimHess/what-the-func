using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funstore.Shared.csharp;
using Funstore.Web.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;

namespace funstore.web.admin.Controllers
{
    public class OrderController : Controller
    {
        private OrderProcessingService _orders;

        public OrderController(IDiscoveryClient discoClient, ILoggerFactory logFactory)
        {
            _orders = new OrderProcessingService(discoClient, logFactory);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "View and Process Orders";

            return View(await _orders.GetAllOrders());
        }

        [Route("[controller]/[action]/{id}/{status}")]
        public async Task<IActionResult> Update(int id, string status)
        {
            var updated = await _orders.UpdateOrderAsync(id, status);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> View(int id)
        {
            var order = await _orders.GetOrderAsync(id);
            foreach(var i in order.Items)
            {
                i.Item = InventoryController.items.First(ii => ii.Id == i.ItemId);
            }
            return View(order);
        }
    }
}