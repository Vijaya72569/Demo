using Microsoft.AspNetCore.Mvc;
using MvcCoreCurd2.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcCoreCurd2.Controllers
{
    public class EmployeeController : Controller
    {
        EmpRepository empRepo = new EmpRepository();

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var employees = empRepo.GetAllEmps();
            EmpModel empModel = new EmpModel();

            if (id.HasValue)
            {
                empModel = employees.FirstOrDefault(e => e.Eid == id.Value) ?? new EmpModel();
            }
           return View(empModel);
        
        }

        [HttpPost]
        public IActionResult Index(EmpModel emp, string str)
        {
            if (!ModelState.IsValid) {
            return View(emp);
            }
            if (str == "Save")
            {
                empRepo.AddUser(emp);
            }
            else if (str == "Update")
            {
                empRepo.UpdateUser(emp);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            empRepo.DeleteEmp(id);
            return RedirectToAction("Index");
        }
    }
}

