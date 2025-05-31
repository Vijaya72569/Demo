using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using WebAppCache.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAppCache.Controllers
{
    public class EmpController : Controller
    {
        public IMemoryCache _imc;
        public EmpContext _ec;
        public EmpController(IMemoryCache imc, EmpContext ec)
        {
            _imc = imc;
            _ec = ec;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            var cacheKey = "emplist";
            if (!_imc.TryGetValue(cacheKey, out List<Emp> emp))
            {
                emp = await _ec.Employ.ToListAsync();
                var s = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                };
                _imc.Set(cacheKey, emp, s);
            }
            return Ok(emp);
        }
    }
}

  
