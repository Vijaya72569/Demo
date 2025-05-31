using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(LogModel obj)
        {
            if (ModelState.IsValid)
            {
             return   RedirectToAction("Success");
            }
            return View(obj);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
