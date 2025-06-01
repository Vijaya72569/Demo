using EFCoreDbWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpWebController : ControllerBase
    {
        EmpContext empcontext;
        public EmpWebController(EmpContext empcontext)
        {
            this.empcontext = empcontext;
        }
        [HttpGet]
        public List<EmpModel> Get(string str)
        {
            List<EmpModel> emps = empcontext.Employe.Where(temp => temp.Ename.Contains(str)).ToList();
            return emps;
        }
      [HttpPost]
        public string Post([FromForm] EmpModel emp)
        {
            empcontext.Employe.Add(emp);
            empcontext.SaveChanges();
            return "Successfully Inserted";
        }
        [HttpPut]
        public string Put([FromForm] EmpModel emp)
        {
            EmpModel e = empcontext.Employe.Where(temp => temp.Ename == emp.Ename).FirstOrDefault();
            e.Ename = emp.Ename;
            e.Email = emp.Email;
            e.Address = emp.Address;
            empcontext.SaveChanges();
            return "Successfully Updated";
        }
        [HttpDelete]
        public string Detete(int eid)
        {
            empcontext.SaveChanges();
            return "Successfully Deleted";
        }

    }
}
