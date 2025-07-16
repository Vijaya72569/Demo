using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSserviceUser.Models;

namespace MSserviceUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserrsDbContext _context;
        public UsersController(UserrsDbContext userrsDbContext)
        {
            _context = userrsDbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Userrs.ToList();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult Adduser(Userrs users)
        {
            _context.Userrs.Add(users);
            _context.SaveChanges();
            return Ok("Insert Successfully");

        }

    }
}