using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSBooks.Models;

namespace MSBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _db;
        public BooksController(BookDbContext bookDbContext) 
        { 
        _db = bookDbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _db.Books.ToList();
            return Ok(books);
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok("insert Successfully");
        }
        [HttpPut]
        public IActionResult Update(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
            return Ok("Update Successfully");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delbook= _db.Books.Find(id);
            _db.Books.Remove(delbook);
            _db.SaveChanges();
            return Ok("delete this id" + id);
        }


    }
}
