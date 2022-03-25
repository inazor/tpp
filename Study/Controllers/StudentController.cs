using Newtonsoft.Json;
using Study.Models;
using Study.Persistence;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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

            var fileName = Path.Combine(Config.RootDirectory, "Study", "DataAccess", "JsonData", "Student.json");
            var studentsContent = ReadJsonFile(fileName);
            var studentsFromJson = DeserializeJsonToType<Student>(studentsContent);
            // ViewBag.Students = studentsFromJson;

            return View();
        }

        public ActionResult Card(int id)
        {
            var student = studentRepository.GetStudentWithCourse(id);
            ViewBag.Student = student;

            ViewBag.CourseId = student.Course?.Id;
            ViewBag.CourseName = student.Course?.Name ?? "";

            return View();
        }

        public static string ReadJsonFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string result = reader.ReadToEnd();
            reader.Close();
            return result;
        }

        public static List<T> DeserializeJsonToType<T>(string json)
        {
            List<T> result = JsonConvert.DeserializeObject<List<T>>(json);
            return result;
        }
    }
}
