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
        private ISqliteDataAccess _sqliteDataAccess;

        public StudentRepository(ISqliteDataAccess sqliteDataAccess = null) : base(sqliteDataAccess)
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
            student.Course = _sqliteDataAccess.GetById<Course>(student.CourseId);
            return student;
        }
    }
}