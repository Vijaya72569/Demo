using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RevalsysTask4.Models;

namespace RevalsysTask4.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmpRepository _empRepo;
        public EmpController(EmpRepository empRepo)
        { 
         _empRepo = empRepo;
        }
        public IActionResult Index()
        {
            var employees = _empRepo.GetAll();

            return View(employees);
        }
        public IActionResult Create()
        {
            var model = new EmpModel()
            {
                Countries = _empRepo.GetCountries(),
                States = new List<SelectListItem>()

            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(EmpModel emp)
        {
            //var model = new EmpModel()
            //{
            //    Countries = _empRepo.GetCountries(),
            //    States = new List<SelectListItem>()

            //};
            if (ModelState.IsValid)
            {
                _empRepo.Add(emp);
                return RedirectToAction("Index");
            }
            return View();
        }
        public JsonResult GetStateByCountry(int countryId)
        {
            var states = _empRepo.GetStates(countryId);
            return Json(states);
        }
        public IActionResult Delete(int id)
        {
            var delemp = _empRepo.GetAll().FirstOrDefault(emp => emp.EmpId == id);
            if (delemp != null)
            {
                _empRepo.Delete(id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var editemp = _empRepo.GetAll().FirstOrDefault(emp => emp.EmpId == id);
            if (editemp != null)
            {
                editemp.Countries = _empRepo.GetCountries();
                editemp.States = _empRepo.GetStates(editemp.CountryId); // Load based on selected country
                return View(editemp);
            }
            return NotFound();

            //return View(editemp);
        }
        [HttpPost]
        public IActionResult Edit(int id,EmpModel emp)
        {
            emp.EmpId = id;
           if(ModelState.IsValid)
            {
                _empRepo.Update(emp);
                return RedirectToAction("Index");
            }
            emp.Countries = _empRepo.GetCountries();
            emp.States = _empRepo.GetStates(emp.CountryId);
            return View(emp);
        }
    }
}
