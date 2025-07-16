using Microsoft.AspNetCore.Mvc;
using TaskCurdNetCore.Models;

namespace TaskCurdNetCore.Controllers
{
    public class EmpController : Controller
    {
        EmpRepository _empRepo;
        public EmpController( EmpRepository empRepo) 
        { 
            _empRepo = empRepo;
        }

        public IActionResult Index()
        {
            var employees=_empRepo.GetEmpList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmpModel emp)
        {
            if (ModelState.IsValid)
            {
                _empRepo.AddEmp(emp);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var editemp=_empRepo.GetEmpList().Find(emp=>emp.Eid==id);
            return View(editemp);
        }
        [HttpPost]
        public IActionResult Edit( int id,EmpModel emp)
        {
            emp.Eid = id;
            if (ModelState.IsValid)
            {
            _empRepo.EditEmp(emp);
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int id)
        { 
         var delemp=_empRepo.GetEmpList().Find(model=>model.Eid==id);
            if(delemp != null)
            {
                _empRepo.DeleteEmp(id);
                return RedirectToAction("Index");
            }
            return View();
        }


    }

}
