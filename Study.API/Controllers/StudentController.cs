using Newtonsoft.Json;
using Study.Core.Repositories;
using Study.Models;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Study.API.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentController()
        {
            _studentRepository = new StudentRepository(Config.DataAccess);
        }

        // GET api/student
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetAll();
        }

        // GET api/student/5
        public Student Get(int id)
        {
            return _studentRepository.GetStudentWithCourseAndCity(id);
        }

        // POST api/student
        public Student Post([FromBody] string value)
        {
            var student = JsonConvert.DeserializeObject<Student>(value);
            _studentRepository.Add(student);
            return student;
        }

        // PUT api/student/5
        public void Put(int id, [FromBody] string value)
        {
            var student = JsonConvert.DeserializeObject<Student>(value);
            _studentRepository.Update(id, student);
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            _studentRepository.Remove(id);
        }
    }
}