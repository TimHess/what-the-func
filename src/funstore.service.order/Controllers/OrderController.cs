using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Funstore.Service.Order.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private static List<Shared.csharp.Order> Orders = new List<Shared.csharp.Order>();

        [HttpGet]
        public IEnumerable<Shared.csharp.Order> Get()
        {
            return Orders;
        }

        // GET api/values
        [HttpGet("history/{cartId}")]
        public IEnumerable<Shared.csharp.Order> History(Guid cartId)
        {
            return Orders.Where(o => o.CartId == cartId);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Shared.csharp.Order Get(int id)
        {
            return Orders.Find(o => o.Id == id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Shared.csharp.Order request)
        {
            var newOrder = new Shared.csharp.Order {
                CartId = request.CartId,
                Items = request.Items,
                OrderPlaced = DateTime.Now,
                Id = Orders.Count + 1,
                Status = "Received"
            };
            Orders.Add(newOrder);
            return Json(newOrder);
        }

        // PUT api/values/5
        [HttpPut("{id}/{status}")]
        public ActionResult Put(int id, string status)
        {
            var order = Orders.First(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else if (order.Status != "Received")
            {
                return BadRequest();
            }
            else
            {
                order.Status = status;
                order.LastUpdate = DateTime.Now;
                return Ok(order);
            }
        }
    }
}
