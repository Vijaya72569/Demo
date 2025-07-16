namespace EmpWebService.Models
{
    public interface IEmpService
    {
        List<Emp> GetAll();
        void Add(Emp emp);
        void Update(Emp emp);
        void Delete(int id);
    }
}
