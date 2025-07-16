using EmpWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpWebAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService  employeeService)
        {
         _employeeService = employeeService;
        }

        public List<Employee> Get() =>_employeeService.GetAll();
        public IActionResult Index()
        {
            return View();
        }
    }
}
