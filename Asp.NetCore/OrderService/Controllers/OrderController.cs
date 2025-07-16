using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }
     //   [HttpGet("place/{productId}")]
        [HttpGet("place/{productId}")]
        public async Task<IActionResult> PlaceOrder(int productId)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:5254/api/product/{productId}");
            return Ok(new { OrderId = 1, Product = response, Status = "Order Placed" });
        }
    }
}
