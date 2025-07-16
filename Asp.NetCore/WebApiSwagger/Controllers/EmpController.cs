using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSwagger.Models;

namespace WebApiSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly EmpRepo _empRepo;
        public EmpController(EmpRepo empRepo)
        {

            _empRepo = empRepo;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var emps = _empRepo.GetAll();
            return Ok(emps);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _empRepo.GetAll().FirstOrDefault(x => x.Id == id);
            // var em=_empRepo.GetEmp(id);
            return Ok(emp);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Emp emp)
        {
            _empRepo.Add(emp);
            return Ok(emp);
        }
        [HttpPut("{id}")]
        public IActionResult Put(Emp emp, int id)
        {
            emp.Id = id;
            _empRepo.Update(emp);
            return Ok(emp);

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _empRepo.Delete(id);
            return Ok(id);
        }
    }
}
