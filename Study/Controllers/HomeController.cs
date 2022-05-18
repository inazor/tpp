using Study.Core.Repositories;
using Study.DataAccess.Repositories;
using Study.Models;
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
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICityRepository _cityRepository;

        public HomeController(IStudentRepository studentRepository, ICourseRepository courseRepository, ICityRepository cityRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _cityRepository = cityRepository;
        }

        public HomeController()
        {
            _studentRepository =  new StudentRepository(Config.DataAccess);
            _courseRepository =  new CourseRepository(Config.DataAccess);
            _cityRepository =  new CityRepository(Config.DataAccess);
        }

        public ActionResult Index()
        {
            var students = _studentRepository.GetAll() ?? new List<Student>();
            ViewBag.Students = students;

            var courses = _courseRepository.GetAll() ?? new List<Course>();
            ViewBag.Courses = courses;

            var cities = _cityRepository.GetAll() ?? new List<City>();
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