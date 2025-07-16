using CurdCoreMultipage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurdCoreMultipage.Controllers
{
    public class EmployeeController : Controller
    {
        EmpRepository _emprepo;
        public EmployeeController(EmpRepository emprepo) 
        {
            _emprepo = emprepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(EmpModel em)
        {
            if (ModelState.IsValid)
            {
               // EmpRepository obj = new EmpRepository();
                _emprepo.AddUser(em);
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
          //  EmpRepository obj = new EmpRepository();
            ModelState.Clear();
            return View(_emprepo.GetEmpAll());
        }
        public IActionResult EditEmp(int id)
        {
           // EmpRepository obj = new EmpRepository();
            return View(_emprepo.GetEmpAll().Find(emp => emp.Empid == id));
        }
        [HttpPost]
        public IActionResult EditEmp(EmpModel obj, int id)
        {
            if (ModelState.IsValid)
            {
               // EmpRepository em = new EmpRepository();
               _emprepo.Update(obj);
                return RedirectToAction("GetAllEmp");
            }
            return View();
        }
        public IActionResult DeleteEmp(int id)
        {
            if (ModelState.IsValid)
            {
              //  EmpRepository obj = new EmpRepository();
                _emprepo.Delete(id);
                return RedirectToAction("GetAllEmp");
            }
            return View();
        }
        public IActionResult GetEmp(int id)
        {
            return View(_emprepo.GetEmp(id));
        
        }
    }
}
