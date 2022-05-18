using Study.Core.Repositories;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study
{
    public class StudentDriver
    {
        private IStudentRepository _studentRepository;

        public StudentDriver(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public List<Student> GetStudentsOrderedByName()
        {
            var students = _studentRepository.GetAll().ToList();
            var sorter = new StudentSorter(students);

            var sortedStudents = sorter.ByName();
            return sortedStudents;
        }

        public List<Student> GetStudentsOrderedByLevel()
        {
            var students = _studentRepository.GetAll().ToList();
            var sorter = new StudentSorter(students);

            var sortedStudents = sorter.ByLevel();
            return sortedStudents;
        }
    }
}