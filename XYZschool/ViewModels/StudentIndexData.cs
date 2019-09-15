using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XYZschool.Models;

namespace XYZschool.ViewModels
{
    public class StudentIndexData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        //public IEnumerable<Models.Grade> Moyennes { get; set; }
        public Grade Grade { get; set; }
    }
}