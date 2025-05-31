using Microsoft.AspNetCore.Mvc;
using WebAppAssign.Models;
namespace WebAppAssign.Controllers
{
    public class UserController : Controller
    {
        public IActionResult UserReg()
        {
            UserModel obj = new UserModel();
            return View(obj);
        }
        [HttpPost]
        public IActionResult UserReg(UserModel obj)
        {
          
                return View("Success");
           
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
