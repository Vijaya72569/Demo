using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebService.Models;

namespace StudentWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) 
        {
         _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var students = _studentService.GetAll();
            return Ok(students);
        }
    }
}
