using Microsoft.AspNetCore.Mvc;
using WebAppAssign.Models;
using System;
namespace WebAppAssign.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Insert()
        {
            CustomerModel cust = new CustomerModel();
            return View(cust);
        }
        [HttpPost]
        public IActionResult Insert(CustomerModel reg)
        {
            if (ModelState.IsValid)
            {
                CustRepository obj = new CustRepository();
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
    }
}
