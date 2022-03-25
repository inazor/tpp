using Study.Core.Repositories;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(IDataAccess dataAccess) : base(dataAccess){}

        public IEnumerable<Student> GetStudentsWithCourses()
        {
            var students = DataAccess.GetEntitites<Student>();
            var studentsWithCourses = new List<Student>();

            foreach (var student in students)
            {
                studentsWithCourses.Add(GetStudentWithCourse(student.Id));
            }

            return studentsWithCourses;
        }

        public Student GetStudentWithCourse(int id)
        {
            var student = DataAccess.GetById<Student>(id);

            if(student.CourseId != null)
            {
                student.Course = DataAccess.GetById<Course>((int)student.CourseId);
            }
            
            return student;
        }
    }
}
