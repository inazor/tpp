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

        public ActionResult List()
        {
            var students = studentRepository.GetAll();
            ViewBag.Students = students;
            return View();
        }

        public ActionResult Card(int id)
        {
            var student = studentRepository.GetStudentWithCourse(id);
            ViewBag.Student = student;
            
            return View();
        }
    }
}
