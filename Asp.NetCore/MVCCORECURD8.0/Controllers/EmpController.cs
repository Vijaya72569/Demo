using Microsoft.AspNetCore.Mvc;
using MVCCORECURD8._0.Models;

namespace MVCCORECURD8._0.Controllers
{
    public class EmpController : Controller
    { 
        private readonly EmpRepository empRepo;
        public EmpController(EmpRepository _empRepo)
        {
            this.empRepo = _empRepo;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var employees = empRepo.GetAllEmps();
            EmpModel empModel = new EmpModel();
            if (id.HasValue)
            {
                empModel = employees.FirstOrDefault(e => e.Eid == id.Value) ?? new EmpModel();
            }
           
            ViewBag.Emplist = employees;
            return View(empModel);
        }
        [HttpPost]
        public IActionResult Index( EmpModel emp, string str)
        {
            if (str == "Save")
            {
               

                empRepo.Adduser(emp);
                return RedirectToAction("Index");
            }
            else if (str == "Update")
            {
               
                empRepo.UpdateUser(emp);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            {
                empRepo.DeleteEmp(id);
                return RedirectToAction("Index");
            }
        }
    }
}

