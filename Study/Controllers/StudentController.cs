using Study.Core.Repositories;
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
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentController()
        {
            _studentRepository = new StudentRepository(Config.DataAccess);
        }

        public ActionResult Delete(int id)
        {
            _studentRepository.Remove(id);

            var students = _studentRepository.GetAll();
            ViewBag.Students = students;
            return View("List");
        }

        public ActionResult List()
        {
            var students = _studentRepository.GetAll();
            ViewBag.Students = students;
            return View();
        }

        public ActionResult Card(int? id)
        {
            if (id == null)
            {
                ViewBag.Student = new Student();
                ViewBag.CourseName = "";
                ViewBag.CityName = "";
                return View();
            }

            var student = _studentRepository.GetStudentWithCourseAndCity((int)id);
            ViewBag.Student = student;

            ViewBag.CourseId = student.Course?.Id;
            ViewBag.CourseName = student.Course?.Name ?? "";
            ViewBag.CityName = student.City?.Name ?? "";

            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (student.Id == 0)
            {
                _studentRepository.Add(student);
            }
            else
            {
                _studentRepository.Update(student.Id, student);
            }

            var students = _studentRepository.GetAll();
            ViewBag.Students = students;
            return View("List");
        }
    }
}
