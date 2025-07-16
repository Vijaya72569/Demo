namespace EFCurdSp.Models
{
    public interface IEmployeeRepository
    {
        void Insert(Employee employee);
        List<Employee> GetAll();
        void Delete(int id);
        Employee GetEmployee(int id);
        void UpdateEmployee(Employee employee);
    }
}
