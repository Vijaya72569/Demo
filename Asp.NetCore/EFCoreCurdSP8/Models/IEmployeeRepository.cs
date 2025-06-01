namespace EFCoreCurdSP8.Models
{
    public interface IEmployeeRepository
    {
       List<Employee> GetAll();
        Employee GetById(int id);
        void Insert(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
