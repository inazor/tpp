using Study.Core.Repositories;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(IDataAccess dataAccess) : base(dataAccess){}

        public Course GetCourseWithStudents(int id)
        {
            var students = DataAccess.GetEntitites<Student>();
            var course = DataAccess.GetById<Course>(id);

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