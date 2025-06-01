using Microsoft.AspNetCore.Mvc;
using WebAppNewVer6._0.Models;

namespace WebAppNewVer6._0.Controllers
{
    public class EmpControllel : Controller
    {
        EmpDbContext context;
        public EmpControllel(EmpDbContext context)
        {
            this.context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
     /*   [HttpPost]
        public async Task<IActionResult> Create(EmpModel obj)
        {
            await context.Employee.AddAsync(obj);
            context.SaveChanges();
            return RedirectToAction("Read");
        }
        public async Task<IActionResult> Read()
        {
            var da = await context.Employee.ToListAsync();
            return View(da);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var da = await context.Employee.Where(n => n.Empid == id).SingleOrDefaultAsync();
            return View(da);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmpModel obj, int id)
        {
            var da = await context.Employee.FirstOrDefaultAsync(n => n.Empid == id);
            if (da != null)
            {
                da.Empid = obj.Empid;
                da.Ename = obj.Ename;
                da.Email = obj.Email;
                da.Address = obj.Address;
                context.SaveChanges();
                return RedirectToAction("Read");
            }
            else
                return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var da = await context.Employee.FirstOrDefaultAsync(n => n.Empid == id);
            if (da != null)
            {
                context.Employee.Remove(da);
                context.SaveChanges();
                return RedirectToAction("Read");
            }
            else
                return View();
        }*/
    }
}
