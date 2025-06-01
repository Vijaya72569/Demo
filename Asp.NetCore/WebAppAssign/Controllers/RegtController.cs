using Microsoft.AspNetCore.Mvc;
using WebAppAssign.Models;

namespace WebAppAssign.Controllers
{
    public class RegtController : Controller
    {
        public IActionResult Add()
        {
            Register rg = new Register();
            return View(rg);
        }
        [HttpPost]
        public IActionResult Add(Register reg)
        {
            if (ModelState.IsValid)
            {
                RigRep obj = new RigRep();
                obj.AddUs(reg);
                return RedirectToAction("Succes");
            }
           
            return View();
        }

        public IActionResult Succes()
        {
            return View();
        }
    }
}

    

