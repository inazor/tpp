using Study.Core.Repositories;
using Study.DataAccess.Repositories;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Persistence.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private Func<int, Course> _courseGetByIdMethod;
        private Func<int, City> _cityGetByIdMethod;

        public StudentRepository(IDataAccess dataAccess) : base(dataAccess)
        {
            _courseGetByIdMethod = DataAccess.GetById<Course>;
            _cityGetByIdMethod = DataAccess.GetById<City>;
        }

        public StudentRepository(IDataAccess dataAccess, ICourseRepository courseRepository, ICityRepository cityRepository) : base(dataAccess)
        {
            _courseGetByIdMethod = courseRepository.GetById;
            _cityGetByIdMethod = cityRepository.GetById;
        }

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

            if (student.CourseId != null)
            {
                student.Course = _courseGetByIdMethod((int)student.CourseId);
            }

            if (student.CityId != null)
            {
                student.City = _cityGetByIdMethod((int)student.CityId);
            }

            return student;
        }
    }
}
