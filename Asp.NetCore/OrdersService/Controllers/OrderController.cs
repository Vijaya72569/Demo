using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public OrderController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
        }
        [HttpGet("place/{productId}")]
        public async Task<IActionResult> PlaceOrder(int productId)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:5042/api/Products/{productId}");
            return Ok(new { OrderId = 1, Product = response, Status = "Order Placed" });
        }
    }
}
