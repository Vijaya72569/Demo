using EmpWebService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpService _empService;
        public EmpController(IEmpService empService) 
        {
        _empService = empService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var emps = _empService.GetAll();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _empService.GetAll().FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");
            return Ok(emp);
        }

        // POST: api/emp
        [HttpPost]
        public IActionResult Post([FromBody] Emp emp)
        {
            if (emp == null)
                return BadRequest("Invalid employee data");

            _empService.Add(emp);
            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }

        // PUT: api/emp
        [HttpPut]
        public IActionResult Put([FromBody] Emp emp)
        {
            if (emp == null)
                return BadRequest("Invalid employee data");

            var existing = _empService.GetAll().FirstOrDefault(e => e.Id == emp.Id);
            if (existing == null)
                return NotFound("Employee not found");

            _empService.Update(emp);
            return Ok("Employee updated successfully");
        }

        // DELETE: api/emp/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _empService.GetAll().FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return NotFound("Employee not found");

            _empService.Delete(id);
            return Ok("Employee deleted successfully");
        }
    }
}

