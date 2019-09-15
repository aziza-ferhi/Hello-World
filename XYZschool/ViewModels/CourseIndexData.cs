using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZschool.ViewModels
{
    public class CourseIndexData
    {
        public IEnumerable<Models.Student> Students { get; set; }
        public IEnumerable<Models.Course> Courses { get; set; }
    }
}