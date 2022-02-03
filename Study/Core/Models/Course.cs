using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Study.Models
{
    public class Course
    {
        //public Course()
        //{
        //    Students = new HashSet<Student>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}