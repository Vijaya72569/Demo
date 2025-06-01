using Microsoft.AspNetCore.Mvc;
using MvcCoreCurdOperations.Models;
using System.Linq;

namespace MvcCoreCurdOperations.Controllers
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
            var viewModel = new EmployeeViewModel
            {
                Employeelist = employees,
                SelectedEmplyee = empModel
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(EmployeeViewModel empview, EmpModel emp, string str)
        {
            if (str == "Save")
            {
                EmpModel selectEmployee = empview.SelectedEmplyee;
                empRepo.Adduser(selectEmployee);
                return RedirectToAction("Index");
            }
            else if (str == "Update")
            {
                empRepo.UpdateUser(empview);
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
