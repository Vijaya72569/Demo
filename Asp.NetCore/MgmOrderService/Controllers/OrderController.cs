using MgmOrderService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MgmOrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly OrderDbContext _context;

        public OrderController(IHttpClientFactory httpClientFactory, OrderDbContext context)
        {
            _httpClient = httpClientFactory.CreateClient();
            _context = context;
        }

        [HttpGet("place/{productId}")]
        public async Task<IActionResult> PlaceOrder(int productId)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:5062/api/Products/{productId}");
            var product = JsonSerializer.Deserialize<Product>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var order = new Order
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductPrice = product.Price,
                Status = "Order Placed"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }
    }
}

