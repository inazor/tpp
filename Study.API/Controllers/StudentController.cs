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
        public Student Post([FromBody] Student value)
        {
            _studentRepository.Add(value);
            return _studentRepository.GetStudentWithCourseAndCity(value.Id);
        }

        // PUT api/student/5
        public Student Put(int id, [FromBody] Student value)
        {
            _studentRepository.Update(id, value);
            return _studentRepository.GetStudentWithCourseAndCity(id);
        }

        // DELETE api/student/5
        public bool Delete(int id)
        {
            var student = _studentRepository.GetStudentWithCourseAndCity(id);
            if (student is null)
            {
                return false;
            }

            _studentRepository.Remove(id);
            return true;
        }
    }
}