using Study.Core.Repositories;
using Study.Models.Interfaces;
using Study.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Models
{
    public class Student : IModel
    {
        private IStudentRepository _studentRepository;

        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Course Course { get; set; }
        public int? CourseId { get; set; }
        public City City { get; set; }
        public int? CityId { get; set; }

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
                if(student.CourseId == CourseId && Id != student.Id)
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
            var result = $"Hello! My name is {Name} and my knowledge level is {Level}.";
            if(Name.Length > 7)
            {
                result += "I have a long name.";
            }
            if(Level > 5)
            {
                result += "My knowledge level is high.";
            }
            return result;
        }
    }
}
