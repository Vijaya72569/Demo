using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using System.Linq;
namespace WebApplication6.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult register()
        {
            RegModel s = new RegModel();
            s.Cities.ToList();
            return View(s);
        }
        [HttpPost]
        public IActionResult register(RegModel obj)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View(obj);
        }
    }
}
