using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
