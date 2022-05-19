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

        // GET api/values
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}