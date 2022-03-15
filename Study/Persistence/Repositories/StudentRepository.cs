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
        private IDataAccess _sqliteDataAccess;

        public StudentRepository(IDataAccess sqliteDataAccess = null) : base(sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess ?? new SqliteDataAccess();
        }

        public IEnumerable<Student> GetStudentsWithCourses()
        {
            var students = _sqliteDataAccess.GetEntitites<Student>();
            var studentsWithCourses = new List<Student>();

            foreach (var student in students)
            {
                studentsWithCourses.Add(GetStudentWithCourse(student.Id));
            }

            return studentsWithCourses;
        }

        public Student GetStudentWithCourse(int id)
        {
            var student = _sqliteDataAccess.GetById<Student>(id);

            if(student.CourseId != null)
            {
                student.Course = _sqliteDataAccess.GetById<Course>((int)student.CourseId);
            }
            else
            {
                student.Course = null;
            }

            
            return student;
        }
    }
}
