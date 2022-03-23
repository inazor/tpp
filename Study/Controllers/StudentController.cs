using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Study.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository studentRepository = new StudentRepository(Config.DataAccess);

        public ActionResult Delete(int id)
        {
            studentRepository.Remove(id);

            var students = studentRepository.GetAll();
            ViewBag.Students = students;
            return View("List");
        }

        public ActionResult List()
        {
            var students = studentRepository.GetAll();
            ViewBag.Students = students;
            return View();
        }

        public ActionResult Card(int id)
        {
            var student = studentRepository.GetStudentWithCourseAndCity(id);
            ViewBag.Student = student;

            ViewBag.CourseId = student.Course?.Id;
            ViewBag.CourseName = student.Course?.Name ?? "";

            ViewBag.CityName = student.City?.Name ?? "";

            return View();
        }
    }
}
