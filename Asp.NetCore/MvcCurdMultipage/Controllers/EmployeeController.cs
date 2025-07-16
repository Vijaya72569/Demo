using Microsoft.AspNetCore.Mvc;
using MvcCurdMultipage.Models;

namespace MvcCurdMultipage.Controllers
{
    public class EmployeeController : Controller
    {
        EmpRepository _emprepo;
        public EmployeeController(EmpRepository emprepo)
        {
        _emprepo = emprepo;
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(EmpModel emp)

        { 
         if(ModelState.IsValid) 
                {
                _emprepo.AddUser(emp);
                return View();
                }
         return View();
        
        }
        public IActionResult GetAllEmp()
        {
            ModelState.Clear();
            return View(_emprepo.GetEmps());
        }
        public IActionResult EditEmp(int id)
        {
            var editemp=_emprepo.GetEmps().Find(emp=>emp.Empid == id);
            return View(editemp);
        }
        [HttpPost]
        public IActionResult EditEmp(EmpModel emp, int id)
        {
            if (ModelState.IsValid)
            {
                _emprepo.UpdateEmp(emp);
                return RedirectToAction("GetAllEmp");
            }
            return View(emp);
        }
        public IActionResult DeleteEmp(int id)
        { 
         var delemp=_emprepo.GetEmps().Find(emp=>emp.Empid==id);
            if(delemp != null)
            {
                _emprepo.DeleteEmp(id);
                return RedirectToAction("GetAllEmp");
            }
            return View();
        
        
        }
    }
}
