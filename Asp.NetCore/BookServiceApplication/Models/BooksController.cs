using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookServiceApplication.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _dbContext;
        public BooksController(BookDbContext dbContext)
        {
        
         _dbContext = dbContext;
        
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_dbContext.Books.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            // return Ok("Book added"); // return plain text Causes Angular to throw ok: false error
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book); // return Json Angular handles it as success
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            if (id != updatedBook.Id)
               
               
                return BadRequest(new { message = "Book ID mismatch" });

            var existingBook = _dbContext.Books.Find(id);
            if (existingBook == null)
                return NotFound(new { message = "Book not found" });

            // Update fields
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Price = updatedBook.Price;
            existingBook.Stock = updatedBook.Stock;

            _dbContext.SaveChanges();

            return Ok(new { message = "Book updated successfully", book = existingBook });

            //    return BadRequest("Book ID mismatch");

            //_dbContext.Entry(updatedBook).State = EntityState.Modified;
            //_dbContext.SaveChanges();
            //return Ok("Book updated");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null) return NotFound(new { message = "Book not found" });

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return Ok(new { message = "Book deleted successfully", deletedBookId = id });
            //   return Ok("Book deleted");
        }


    }
}
