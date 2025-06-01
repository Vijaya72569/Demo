using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using WebAppCoreCURD.Models;
namespace WebAppCoreCURD.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(EmpModel em)
        {
            if (ModelState.IsValid)
            {
                EmpRepository obj = new EmpRepository();
                obj.AddUser(em);
                return RedirectToAction("GetAllEmp");
            }
            else
            {
                ViewBag.msg = "Invalid Details";
            }
            return View();

        }
        public IActionResult GetAllEmp()
        {
            EmpRepository obj = new EmpRepository();
            ModelState.Clear();
            return View(obj.GetEmpAll());
        }
        public IActionResult EditEmp(int id)
        {
            EmpRepository obj = new EmpRepository();
            return View(obj.GetEmpAll().Find(emp => emp.Empid == id));
        }
        [HttpPost]
        public IActionResult EditEmp(EmpModel obj, int id)
        {
            if (ModelState.IsValid)
            {
                EmpRepository em = new EmpRepository();
                em.Update(obj);
                return RedirectToAction("GetAllEmp");
            }
            return View();
        }
        public IActionResult DeleteEmp(int id)
        {
            if (ModelState.IsValid)
            {
                EmpRepository obj = new EmpRepository();
                obj.Delete(id);
                return RedirectToAction("GetAllEmp");
            }
            return View();
        }
    }
}
