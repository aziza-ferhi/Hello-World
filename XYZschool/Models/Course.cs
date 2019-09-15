using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZschool.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public object DepartmentId { get; internal set; }
    }
}