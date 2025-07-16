
namespace StudentWebService.Models
{
    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new()
        {
            new Student{Id=1,Name="Vijaya",Branch="ECE"},
             new Student{Id=2,Name="Vijay",Branch="EEE"},
              new Student{Id=3,Name="Ajay",Branch="Civil"},
               new Student{Id=4,Name="Kalam",Branch="CSE"}
        };
        public List<Student> GetAll() => _students;
      
    }
}
