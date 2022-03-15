using Study.Core.Repositories;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private IDataAccess _sqliteDataAccess;

        public CourseRepository(IDataAccess sqliteDataAccess = null) : base(sqliteDataAccess)
        {
            _sqliteDataAccess = sqliteDataAccess ?? new SqliteDataAccess();
        }

        public Course GetCourseWithStudents(int id)
        {
            var students = _sqliteDataAccess.GetEntitites<Student>();
            var course = _sqliteDataAccess.GetById<Course>(id);

            course.Students = new List<Student>();
            foreach (var student in students)
            {
                if (student.CourseId == id)
                {
                    course.Students.Add(student);
                }
            }
            return course;
        }
    }
}