using EFCurdSp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCurdSp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _emprepo;
        public EmployeeController(IEmployeeRepository emprepo)
        {
            _emprepo = emprepo;
        }

        public IActionResult Index(int? editid)
        {
            var editemp=editid.HasValue ? _emprepo.GetEmployee(editid.Value) : new Employee();
            ViewBag.Editemp=editemp;
            var employees=_emprepo.GetAll().ToList();
            return View(employees);
        }
        [HttpPost]
        public IActionResult Save(Employee emp)
        {
            if (emp.EId == 0)
            {


                _emprepo.Insert(emp);
                return RedirectToAction("Index");
            }
            else
            {
               _emprepo.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }

        }
        public IActionResult Delete(int id)
        { 
        _emprepo.Delete(id);
            return RedirectToAction("Index");
        }
       
    }
}
