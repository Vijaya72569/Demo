using CoreEFCurd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreEFCurd.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList() ;
            return View(products);
        }
        [HttpPost]
        public IActionResult Create(Product product) 
        {
            if (ModelState.IsValid) 
            { 
                _context.Products.Add(product);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        
        }

        [HttpPost]
        public IActionResult Update(Product product) 
        {
            if (ModelState.IsValid) 
            
           { 
            _context.Products.Update(product);
                _context.SaveChanges();
            
            }
            return RedirectToAction("Index");
        
        }

        [HttpPost]
        public IActionResult Delete(int Pid)
        {
            var product = _context.Products.Find(Pid);
            if (product != null)
            { 
             _context.Products.Remove(product);
                _context.SaveChanges();
            
            }
            return RedirectToAction("Index");
        
        }
    }
}
