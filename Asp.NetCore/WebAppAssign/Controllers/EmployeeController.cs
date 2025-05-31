using Microsoft.AspNetCore.Mvc;
using WebAppAssign.Models;
namespace WebAppAssign.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Emp e = new Emp();
            return View(e);
        }
        [HttpPost]
        public IActionResult Index(Emp em)
        {
            em.TotalSal = 0;


            if (ModelState.IsValid)
            {
                 em.TotalSal = em.Sal + em.Commision;
            }
            return View(em);
    }
    }
}
