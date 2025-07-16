
namespace StudentWebApi.Models
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new()
        {
            new Student{Id=1,Name="Vijaya",Branch="ECE"},
            new Student{Id=2,Name="kalam",Branch="Civil" }
        };
        public List<Student> GetAll()=>_students;
        
          //  throw new NotImplementedException();
          
        
    }
}
