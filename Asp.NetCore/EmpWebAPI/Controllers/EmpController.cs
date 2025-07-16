using EmpWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmpController(IEmployeeService employeeService)
        { 
        _employeeService = employeeService;
         
        }

        [HttpGet]
        public IActionResult Get()
        {
            var emps = _employeeService.GetAll();
            return Ok(emps);
        }
    }
}
