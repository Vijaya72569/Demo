using EFCoreCurdSP8.Models;
using Microsoft.EntityFrameworkCore;
namespace EFCoreCurdSP8.Models
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmpDbContext _context;
        public EmployeeRepository(EmpDbContext context)
        {
            _context = context;
        }
        public List<Employee> GetAll() => 
        _context.Set<Employee>().FromSqlRaw("EXEC GetAllEmp").ToList();
        public Employee? GetById(int id) =>
            _context.Set<Employee>().FromSqlRaw("EXEC GetEmpById @p0", id).AsEnumerable().FirstOrDefault();
        public void Insert(Employee emp) =>
            _context.Database.ExecuteSqlRaw("EXEC InsertEmp @p0,@p1", emp.Name, emp.Salary);
        public void Update(Employee emp)=>
            _context.Database.ExecuteSqlRaw("EXEC UpdateEmp @p0,@p1,@p2",emp.Id,emp.Name, emp.Salary);
        public void Delete(int id) =>
            _context.Database.ExecuteSqlRaw("EXEC DeleteEmp @p0", id);

    }
}
