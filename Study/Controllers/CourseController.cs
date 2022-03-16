using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Study.Controllers
{
    public class CourseController : Controller
    {
        private CourseRepository courseRepository = new CourseRepository(Config.DataAccess);

        public ActionResult List()
        {
            var courses = courseRepository.GetAll();
            ViewBag.Courses = courses;
            return View();
        }

        public ActionResult Card(int id)
        {
            var course = courseRepository.GetCourseWithStudents(id);
            ViewBag.Course = course;
            
            return View();
        }
    }
}
