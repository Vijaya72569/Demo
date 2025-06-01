using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCoreCURD.Models;
namespace WebApiCoreCURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        EmContext context;
        public WebApiController(EmContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Emp> Get(string str)
        {
            List<Emp> emp = context.Employ.Where(temp => temp.Ename.Contains(str)).ToList();
            return emp;
        }
        [HttpPost]
        public string Post([FromForm] Emp emp)
        {
            context.Employ.Add(emp);
            context.SaveChanges();
            return "Successfully Inserted";
        }
        [HttpPut]
        public string Put([FromForm]Emp emp)
        {
            Emp e = context.Employ.Where(temp => temp.EmpId == emp.EmpId).FirstOrDefault();
            e.Ename = emp.Ename;
            e.Email = emp.Email;
            e.Address = emp.Address;
            context.SaveChanges();
            return "Successfully Updated";
        }
        [HttpDelete]
        public string Detete(int eid)
        {
            Emp em = context.Employ.Where(temp => temp.EmpId == eid).FirstOrDefault();
            context.Employ.Remove(em);
            context.SaveChanges();
            return "Successfully Deleted";
        }
    }
}
