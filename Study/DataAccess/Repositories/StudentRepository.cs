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
                studentsWithCourses.Add(GetStudentWithCourseAndCity(student.Id));
            }

            return studentsWithCourses;
        }

        public Student GetStudentWithCourseAndCity(int id)
        {
            var student = DataAccess.GetById<Student>(id);

            if(student.CourseId != null)
            {
                student.Course = DataAccess.GetById<Course>((int)student.CourseId);
            }
            
            if(student.CityId != null)
            {
                student.City = DataAccess.GetById<City>((int)student.CityId);
            }
            
            return student;
        }
    }
}
