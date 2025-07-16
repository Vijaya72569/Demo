using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApplication.Models;

namespace UserApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UsersController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            //return Ok("User registered");
            return Ok(new { message = "User registered" });

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (existingUser == null)
                //return Unauthorized("Invalid credentials");
                return Unauthorized(new { message = "Invalid credentials" });

            //return Ok(existingUser);
            return Ok(new
            {
                message = "Login successful",
                user = existingUser
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

    }
}
