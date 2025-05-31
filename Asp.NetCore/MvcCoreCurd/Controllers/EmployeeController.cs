using Microsoft.AspNetCore.Mvc;
using MvcCoreCurd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace MvcCoreCurd.Controllers
{
    public class EmployeeController : Controller
    {
        EmpRepository empRepo = new EmpRepository();
        [HttpGet]
        //public IActionResult Index()
        //{
        //    List<EmpModel> empList = empRepo.GetEmps();
        //    TempData["emps"] = empList;
        //    TempData.Keep();

        //    return View(empList);
        //}

        public IActionResult Index(int? id)
        {
            var employees = empRepo.GetEmps(); // Fetch all employees
            EmpModel emp = new EmpModel();

            // If an ID is provided, fetch the employee for editing
            if (id.HasValue)
            {
                emp = employees.FirstOrDefault(e => e.Eid == id.Value) ?? new EmpModel();
            }

            var viewModel = new EmployeeViewModel
            {
                EmployeeList = employees,
                SelectedEmployee = emp
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(EmpModel emp, string str,EmployeeViewModel emp1)
        {
            

            if (str == "Save")
            {
                EmpModel selectedEmployee = emp1.SelectedEmployee;
                empRepo.AddUser(selectedEmployee);
                return RedirectToAction("Index");
            }
            else if (str == "Update")
            {
                empRepo.UpdateUser(emp1);
                return RedirectToAction("Index");
            }
            return View();
        }
        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //   // TempData.Keep();
        //    Models.EmpModel empModel = new Models.EmpModel();
        //    empModel.Eid = id;
        //    Models.EmpModel em = empRepo.SearchEmp(empModel);
        //    return RedirectToAction("Index", em);
        //}
        [HttpGet]

        public IActionResult Delete(int id)
        {

            empRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
