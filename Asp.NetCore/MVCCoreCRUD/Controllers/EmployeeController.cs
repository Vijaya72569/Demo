using Microsoft.AspNetCore.Mvc;
using MVCCoreCRUD.Models;
using System.Linq;

namespace MVCCoreCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmpRepository empRepository= new EmpRepository();
        [HttpGet]
        public IActionResult Index( int? id)
        {
            var employees=empRepository.GetAllEmps();
            EmpModel empModel = new EmpModel();
            if (id.HasValue)
            {
                empModel=employees.FirstOrDefault(e=>e.Eid==id.Value) ?? new EmpModel();
            }

            return View(empModel);
        }
        [HttpPost]
        public IActionResult Index(EmpModel emp,string str)
        {
            if (!ModelState.IsValid)
            {
                return View(emp);
            }
            if (str == "Save")
            {
             empRepository.AddUser(emp);
                return RedirectToAction("Index");
            }
            
            else if (str == "Update")
            {
                empRepository.UpdateUser(emp);
                return RedirectToAction("Index");
            }
          
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        
        { 

            empRepository.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}
