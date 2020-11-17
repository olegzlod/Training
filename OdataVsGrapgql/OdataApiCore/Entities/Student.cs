using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataApiCore.Entities
{
    public class Student
    {

        public String Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
