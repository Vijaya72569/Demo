using EFCurdSp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
namespace EFCurdSp.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
       private readonly EmpDbContext _context;
        public EmployeeRepository(EmpDbContext context)
        { 
         _context = context;
        }
        public void Insert(Employee employee) =>
            _context.Database.ExecuteSqlRaw("EXEC InsertEmp @p0,@p1", employee.Name, employee.Salary);
       public List<Employee> GetAll()=>
            _context.Set<Employee>().FromSqlRaw("EXEC GetAllEmp").ToList();
        public void Delete(int id) =>
            _context.Database.ExecuteSqlRaw("EXEC DeleteEmp @p0", id);
        public Employee? GetEmployee(int id) =>
            _context.Set<Employee>().FromSqlRaw("EXEC GetEmpById @p0", id).AsEnumerable().FirstOrDefault();
        public void UpdateEmployee(Employee employee) =>
            _context.Database.ExecuteSqlRaw("UpdateEmp @p0,@p1,@p2", employee.EId, employee.Name, employee.Salary);
    }
}
