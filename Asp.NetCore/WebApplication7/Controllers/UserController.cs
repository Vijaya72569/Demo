using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
