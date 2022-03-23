using Study.DataAccess.Repositories;
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
        private StudentRepository studentRepository = new StudentRepository(Config.DataAccess);
        private CourseRepository courseRepository = new CourseRepository(Config.DataAccess);
        private CityRepository cityRepository = new CityRepository(Config.DataAccess);

        public ActionResult Index()
        {
            var students = studentRepository.GetAll();
            ViewBag.Students = students;

            var courses = courseRepository.GetAll();
            ViewBag.Courses = courses;

            var cities = cityRepository.GetAll();
            ViewBag.Cities = cities;

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