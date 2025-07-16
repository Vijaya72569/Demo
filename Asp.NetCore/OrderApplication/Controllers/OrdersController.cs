using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApplication.Models;
using System.Linq.Expressions;

namespace OrderApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _context;

        public OrdersController(OrderDbContext context)
        {
            _context = context;
        }

        //[HttpPost]
        //public IActionResult PlaceOrder(Order order)
        //{
        //    order.OrderDate = DateTime.UtcNow;
        //    order.Status = "Pending";
        //    _context.Orders.Add(order);
        //    _context.SaveChanges();
        //    return Ok("Order placed successfully");
        //}
        // add code

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            try
            {


                order.OrderDate = DateTime.UtcNow;
                order.Status = "Pending";
                _context.Orders.Add(order);
                _context.SaveChanges();

                // 🔔 Call NotificationService using HttpClient
                using var client = new HttpClient();
                var notification = new
                {
                    toEmail = "user@example.com", // Replace with order.UserEmail if available
                   
                    subject = "Order Placed",
                    body = $"Your order #{order.Id} has been received successfully."
                };

                await client.PostAsJsonAsync("http://localhost:5005/api/notifications", notification);

                return Ok(new { message = "Order placed successfully", id = order.Id });
            }
            catch (Exception ex)
            {
                // Console.WriteLine("❌ Order failed: " + ex.Message);
                Console.WriteLine("❌ Order failed: " + ex.ToString());
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }


        }



                [HttpGet("user/{userId}")]
        public IActionResult GetOrdersByUser(int userId)
        {
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

    }
}
