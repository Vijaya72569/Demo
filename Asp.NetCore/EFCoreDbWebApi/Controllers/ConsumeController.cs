using Microsoft.AspNetCore.Mvc;

namespace EFCoreDbWebApi.Controllers
{
    public class ConsumeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
