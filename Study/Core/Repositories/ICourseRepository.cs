using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetCourseWithStudents(int id);
    }
}
