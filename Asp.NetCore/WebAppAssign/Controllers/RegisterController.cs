using Microsoft.AspNetCore.Mvc;
using WebAppAssign.Models;
using System;
namespace WebAppAssign.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Insert()
        {
           RegModel reg = new RegModel();
            return View(reg);
        }
        [HttpPost]
        public IActionResult Insert(RegModel reg)
        {
            if (ModelState.IsValid)
            {
                RegRepository obj = new RegRepository();
                obj.AddUser(reg);
                return View("Success");
            }
            /*    catch (Exception ex)
                 {
                     ViewBag.Exception = ex.Message;
                     return View();

                 }*/
            return View();
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
