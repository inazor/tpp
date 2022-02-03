using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Study.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var studentRepository = new StudentRepository();
            var students = studentRepository.GetAll();
            ViewBag.Students = students;

            var courseRepository = new CourseRepository();
            var courses = courseRepository.GetAll();
            ViewBag.Courses = courses;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}