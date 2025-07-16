using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSUser.Models;

namespace MSUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        public UsersController(UserDbContext userDbContext)
        { 
         _userDbContext = userDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userDbContext.Users.ToList();
            return Ok(users);
        }
        [HttpPost]
        public IActionResult Adduser(Users users)
        { 
        _userDbContext.Users.Add(users);
            _userDbContext.SaveChanges();
            return Ok("Insert Successfully");
        
        }
    }
}
