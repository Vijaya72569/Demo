using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using WebApplication10.Models;
namespace WebApplication10.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LoginCheck()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginCheck(Login obj)
        {
            if (ModelState.IsValid)
            {
                LoginRepository s = new LoginRepository();
                if (s.CheckUser(obj.Username, obj.Password))
                {
                    return View("Success", obj);
                }
                else
                {
                    ViewBag.msg = "Invalid Username & Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
          }
        public IActionResult Success()
        {
            return View();
        }
        }
    }

