using EFCoreDbWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        EmpContext context;
        public WebApiController(EmpContext context)
        {
            this.context = context;
        }
        public List<EmpModel> Get()
        {
            List<EmpModel> emps = context.Employe.ToList();
            return emps;
        }
    }
}
