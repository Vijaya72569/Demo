using EFCoreCurdSP8.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCurdSP8.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeController(IEmployeeRepository empRepository)
        {
            _empRepo = empRepository;
        }

        public IActionResult Index(int? editId)
        {
            var employees = _empRepo.GetAll();
            var editemp=editId.HasValue ? _empRepo.GetById(editId.Value) : new Employee();
            ViewBag.EditId = editemp;

            return View(employees);
        }
        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            if (employee.Id == 0)
            { 
             _empRepo.Insert(employee);
            }
            else
            {
                _empRepo.Update(employee);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
         _empRepo.Delete(id);
            return RedirectToAction("Index");
        
        }
    }
}
