using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIEFCurd.Models;

namespace WebAPIEFCurd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpRepository _empRepository;
        public EmpController(EmpRepository empRepository)
        {
            _empRepository = empRepository;

        }
        [HttpGet]
        public List<Emp> Get()
        {
            return _empRepository.GetAll();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Emp emp)
        {
            _empRepository.Add(emp);
            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp); // ✅ 201 Created
            //return Ok(emp);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var emp= _empRepository.GetById(id);
            if (emp != null)
            {
                return Ok(emp);
            }
            return NotFound("ID does not exist in database");//404	Record with specified ID does not exist in database.
        }

        [HttpPut("{id}")]
        public IActionResult Put(Emp emp, int id)
        {
            if (id != emp.Id)
            {
                return BadRequest("ID mismatch");
            }

            try
            {
                _empRepository.Update(emp);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent(); // 204: success with no body
        }
    [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delid = _empRepository.GetAll().FirstOrDefault(x => x.Id == id);
            if (delid != null)
            {
                _empRepository.Delete(id);
                return Ok(id);
            }
            return BadRequest("not Available");
           
        }
    }
}
