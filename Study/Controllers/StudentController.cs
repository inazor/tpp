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
        public ActionResult List()
        {
            var studentRepository = new StudentRepository();
            var students = studentRepository.GetAll();
            ViewBag.Students = students;
            return View();
        }

        public ActionResult Card(int id)
        {
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetById(id);
            ViewBag.Student = student;
            return View();
        }
    }
}