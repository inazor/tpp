using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentWithCourse(int id);
        IEnumerable<Student> GetStudentsWithCourses();
    }
}
