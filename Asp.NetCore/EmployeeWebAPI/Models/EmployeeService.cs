namespace EmployeeWebAPI.Models
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService() { }
        private readonly List<Employee> _employees = new()
        {
            new Employee { Id = 1,Name="Vijaya",Salary=25000 },
            new Employee {Id=2,Name="Ajay",Salary=29000}
            };

        public List<Employee> GetAll() => _employees;

        public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            var emp = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var editemp=GetById(employee.Id);
            if (editemp != null)
            {
                editemp.Name = employee.Name;
                editemp.Salary = employee.Salary;
            }

        }

        public void Delete(int id)
        {

            var delemp=GetById(id);
            if (delemp != null)
            {
                _employees.Remove(delemp);
            }
        }

    }
}
