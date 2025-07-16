using EFCoreCurdCodeFirst8.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCurdCodeFirst8.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmpDbContext _empDbContext;
        public EmpController(EmpDbContext empDbContext)
        {
         _empDbContext = empDbContext;
        }
        public IActionResult Index(int? id)
        {
            EmpModel? empModel = null;
            if (id.HasValue)
            { 
             empModel=_empDbContext.Emps.Find(id.Value);
            }
            ViewBag.editemp=empModel;
            var employees=_empDbContext.Emps.ToList();
            return View(employees);
        }

        [HttpPost]
        public IActionResult Create(EmpModel emp)
        {
              _empDbContext.Emps.Add(emp);
                _empDbContext.SaveChanges();

                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(EmpModel emp)
        {
            _empDbContext.Emps.Update(emp);
            _empDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
            var delemp= _empDbContext.Emps.Where(e=>e.Eid==id).FirstOrDefault();
            if (delemp != null)
            {
                _empDbContext.Emps.Remove(delemp);
                _empDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
