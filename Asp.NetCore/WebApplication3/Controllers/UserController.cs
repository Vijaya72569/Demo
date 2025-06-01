using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("Website1")]
    public class UserController : Controller
    {
        [Route(" ")]
        [Route("My Method")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
