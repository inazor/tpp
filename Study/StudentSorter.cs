using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study
{
    public class StudentSorter
    {
        private readonly List<Student> _students;

        public StudentSorter(List<Student> students)
        {
            _students = students;
        }

        public List<Student> ByName()
        {
            var result = _students.OrderBy(s => s.Name).ToList();
            return result;
        }

        public List<Student> ByLevel()
        {
            var result = _students.OrderBy(s => s.Level).ToList();
            return result;
        }
    }
}