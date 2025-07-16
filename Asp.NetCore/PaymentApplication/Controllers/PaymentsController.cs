using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApplication.Models;

namespace PaymentApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentDbContext _context;
        public PaymentsController(PaymentDbContext context) 
        {
         _context = context;
        }

        //[HttpPost]
        //public IActionResult MakePayment(Payment payment)
        //{
        //    payment.PaymentDate = DateTime.UtcNow;
        //    payment.Status = "Success"; // simulate success
        //    _context.Payments.Add(payment);
        //    _context.SaveChanges();

        //    return Ok("Payment successful");
        //}

        // add code

        [HttpPost]
        public async Task<IActionResult> MakePayment(Payment payment)
        {
            try
            {


                payment.PaymentDate = DateTime.UtcNow;
                payment.Status = "Success";
                _context.Payments.Add(payment);
                _context.SaveChanges();

                // 🔔 Notify user via NotificationService
                var client = new HttpClient();
                var notification = new
                {
                    toEmail = "user@example.com",
                    subject = "Payment Successful",
                    body = $"Payment for Order #{payment.OrderId} is successful."
                };
                await client.PostAsJsonAsync("http://localhost:5005/api/notifications", notification);

                // return Ok("Payment successful");
                return Ok(new { message = "Payment successful" });

            }
            catch (Exception ex)
            {
                Console.WriteLine("Payment error: " + ex.Message);
                return StatusCode(500, new { message = "Payment failed", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPayment(int id)
        {
            var payment = _context.Payments.Find(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

    }
}
