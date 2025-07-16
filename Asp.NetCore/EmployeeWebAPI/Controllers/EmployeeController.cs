using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
        
        _employeeService = employeeService;
        }
        [HttpGet]
        public List<Employee> Get()=>_employeeService.GetAll();

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _employeeService.Add(employee);
            return Ok(employee);
        }
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            var emp=_employeeService.GetById(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put(Employee employee,int id)
        {
           
            if (id != employee.Id) 
            {
                return BadRequest();
            }
            _employeeService.Update(employee);
            return Ok(employee);


        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delemp=_employeeService.GetById(id);
            if(delemp != null)
            {
                _employeeService.Delete(id);
            }
            return Ok();
        }
    }
}
