
namespace EmpWebService.Models
{
    public class EmpService : IEmpService
    {
        private readonly List<Emp> employees = new()
        {
            new Emp { Id = 1,Name="vijaya",Salary=30000 },
             new Emp { Id = 2,Name="kalam",Salary=20000 },
              new Emp { Id = 3,Name="vijay",Salary=29000 },
               new Emp { Id = 4,Name="Ajay",Salary=25000 }
        };

        public List<Emp> GetAll() => employees;
        public void Add(Emp emp)
        {
            // Generate new Id (assuming max Id + 1)
            int newId = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            emp.Id = newId;
            employees.Add(emp);
        }

        public void Update(Emp emp)
        {
            var existingEmp = employees.FirstOrDefault(e => e.Id == emp.Id);
            if (existingEmp != null)
            {
                existingEmp.Name = emp.Name;
                existingEmp.Salary = emp.Salary;
            }
        }

        public void Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
            }
        }
    }
}
