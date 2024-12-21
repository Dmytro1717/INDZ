using Microsoft.AspNetCore.Mvc;
using FoodDeliveryAPI.Models;
using System.Collections.Generic;

namespace FoodDeliveryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // Для простоти використовуємо список замість бази даних
        private static List<Order> orders = new List<Order>
        {
            new Order { Id = 1, CustomerName = "John", FoodItem = "Pizza", Price = 12.99, Status = "Pending" },
            new Order { Id = 2, CustomerName = "Alice", FoodItem = "Burger", Price = 8.99, Status = "Delivered" }
        };

        // GET: api/orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = orders.Find(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            order.Id = orders.Count + 1;
            orders.Add(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Order order)
        {
            var existingOrder = orders.Find(o => o.Id == id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.FoodItem = order.FoodItem;
            existingOrder.Price = order.Price;
            existingOrder.Status = order.Status;

            return NoContent();
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = orders.Find(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            orders.Remove(order);
            return NoContent();
        }
    }
}
