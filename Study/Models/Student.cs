using Study.Core.Repositories;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Models
{
    public class Student
    {
        private IStudentRepository _studentRepository;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Course Course { get; set; }
        public int? CourseId { get; set; }

        public Student()
        {
            _studentRepository = new StudentRepository(Config.DataAccess);
        }

        public Student(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Enroll(Course course)
        {
            if (!CanEnrollToCourse(course.Level))
            {
                throw new ArgumentException($"Student of level {Level} cannot be enrolled into course of Level {course.Level}");
            }

            CourseId = course.Id;
            _studentRepository.Update(Id, this);
        }

        public int GetNumberOfCourseMates()
        {
            int result = 0;
            var students = _studentRepository.GetStudentsWithCourses();

            foreach (var student in students)
            {
                if(student.Course.Id == Course.Id)
                {
                    result++;
                }
            }

            return result;
        }

        public bool CanEnrollToCourse(int courseLevel)
        {
            if (Level == courseLevel - 1)
            {
                return true;
            }
            return false;
        }

        public string Introduce()
        {
            return $"Hello! My name is {Name} and my knowledge level is {Level}.";
        }
    }
}
