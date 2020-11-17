using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataApiCore.Entities
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
