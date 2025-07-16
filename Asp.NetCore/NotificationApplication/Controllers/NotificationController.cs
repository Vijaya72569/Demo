using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationApplication.Models;

namespace NotificationApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        [HttpPost]
        public IActionResult SendEmail([FromBody] EmailNotification notification)
        {
            // Simulate email by logging to console
            Console.WriteLine("Sending Email:");
            Console.WriteLine($"To: {notification.ToEmail}");
            Console.WriteLine($"Subject: {notification.Subject}");
            Console.WriteLine($"Body: {notification.Body}");

            // In real apps: use SMTP or external services like SendGrid
            return Ok("Email sent (simulated)");
        }

    }
}
