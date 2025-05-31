using EFCURDCORE8.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCURDCORE8.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpDbContext _dbContext;
        public EmployeeController(EmpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

            public IActionResult Index(int? id)
        {
            var employees=_dbContext.Employee.ToList();
            EmpModel? emp = null;
            if (id.HasValue)
            { 
            emp=_dbContext.Employee.Find(id.Value);
            }
            ViewBag.EditEmp=emp;
            return View(employees);
        }
        [HttpPost]
        public IActionResult Create(EmpModel obj) 
        {
            if (ModelState.IsValid) 
            {
             _dbContext.Employee.Add(obj);
              _dbContext.SaveChanges();
            }
        return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(EmpModel obj)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Employee.Update(obj);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var empid = _dbContext.Employee.Find(id);
            if (empid != null) 
            { 
             _dbContext.Employee.Remove(empid);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
