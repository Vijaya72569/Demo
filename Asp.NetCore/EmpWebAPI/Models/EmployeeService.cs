namespace EmpWebAPI.Models
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new()
        {
            new Employee { Id = 1, Name="Vijaya",Salary=25000 },
            new Employee { Id = 2, Name="Ajay",Salary=28000 }
            };
        public List<Employee> GetAll() => _employees;

    }
}
