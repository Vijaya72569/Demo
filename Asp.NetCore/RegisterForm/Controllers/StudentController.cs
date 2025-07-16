using Microsoft.AspNetCore.Mvc;
using RegisterForm.Models;

namespace RegisterForm.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly List<string> Courses = new() { "B-Tech", "B-Sc", "MSC", "MBA" };
        private readonly List<string> Skills = new() { "C#", "Java", "Python", "Angular" };
        private readonly List<string> Hobbies = new() { "Reading", "Traveling", "Music", "Gaming" };
        public StudentController(StudentRepository studentRepository) 
        
        {
        _studentRepository = studentRepository;
        
        }

        public IActionResult Index()
        {
           var students= _studentRepository.GetStudents().ToList();
            return View(students);
        }
        public void LoadViewData()
        {
            ViewBag.courses=Courses;
            ViewBag.skills=Skills;
            ViewBag.hobbies=Hobbies;
        }

        public IActionResult Register()
        {
            LoadViewData();
            return View(new StudentModel());

        }
        [HttpPost]
        public IActionResult Register(StudentModel student)
        {
            if(ModelState.IsValid)
            {
                _studentRepository.Add(student);
                return RedirectToAction("Index");
            }
            LoadViewData();
            return View(student);
        }
        public IActionResult Update( int id)
        {
            LoadViewData();
            var editstu=_studentRepository.GetStudents().FirstOrDefault(m=>m.Sid == id);
            return View(editstu);

        }
        [HttpPost]
        public IActionResult Update(int id, StudentModel student)
        {
            if (ModelState.IsValid)
            {

                student.Sid = id;
                // var editstu = _studentRepository.GetStudents().FirstOrDefault(m => m.Sid == id);
                _studentRepository.Update(student);
                LoadViewData();
                return RedirectToAction("Index");
            }
            return View(student);
        }
        public IActionResult Delete(int id)
        {
            _studentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
