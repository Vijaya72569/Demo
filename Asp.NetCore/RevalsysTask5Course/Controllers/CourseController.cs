using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RevalsysTask5Course.Models;

namespace RevalsysTask5Course.Controllers
{
    public class CourseController : Controller
    {
        CourseRepository  _courseRepository;
        public CourseController(CourseRepository courseRepository)
        {
         _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            var courses= _courseRepository.GetAll();
            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _courseRepository.AddCourse(obj);
                    return RedirectToAction("Index");
                }
            }
            catch (SqlException ex)
            {
                ViewBag.msg = "Sql Error";
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Something went wrong Try Again";
            }

            return View();
        }

        [AcceptVerbs("Get", "POST")]
        public IActionResult CourseCodeValid(string CourseCode)
        {
            bool exists = _courseRepository.CourseValid(CourseCode);
            if (exists)
            {
                return Json($"Course code '{CourseCode}' is already in use.");
            }
            return Json(true);
        }

        public IActionResult Edit(int id)
        {
            var editcourse = _courseRepository.GetAll().Find(m => m.CourseId == id);
            return View(editcourse);
        }
        [HttpPost]
        public IActionResult Edit(CourseModel obj,int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.CourseId = id;
                    _courseRepository.EditCourse(obj);
                    return RedirectToAction("Index");
                }
            }
            catch (SqlException ex)
            {
                ViewBag.msg = "Sql Error";
            }
            catch (Exception ex)
            {
                ViewBag.msg = "Something went wrong Try Again";
            }

            return View();
        }
        public IActionResult Delete(int id)
        {
            var delcourse = _courseRepository.GetAll().Find(m => m.CourseId == id);
            if (delcourse != null)
            {
                _courseRepository.DeleteCourse(id);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Details(int id) 
        {
            var details = _courseRepository.CourseDetail(id);
            return View(details);
        }

    }
}
